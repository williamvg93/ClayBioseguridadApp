using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Post.Authentication;
using ApiClayBio.Helpers;
using Domain.Entities.Authentication;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Authorization = ApiClayBio.Helpers.Authorization;

namespace ApiClayBio.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<User> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var user = new User
        {
            Email = registerDto.Email,
            Name = registerDto.Name/* ,
            Password = registerDto.Password */
        };

        //Encrypt password
        user.Password = _passwordHasher.HashPassword(user, registerDto.Password);

        var existingUser = _unitOfWork.Users
                                    .Find(u => u.Name.ToLower() == registerDto.Name.ToLower())
                                    .FirstOrDefault();

        if (existingUser == null)
        {
            var rolDefault = _unitOfWork.Roles
                                    .Find(u => u.Name == Authorization.rol_default.ToString())
                                    .First();
            try
            {
                user.Rols.Add(rolDefault);
                _unitOfWork.Users.Add(user);
                await _unitOfWork.SaveAsync();

                return $"User  {registerDto.Name} has been registered successfully";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"User {registerDto.Name} already registered.";
        }
    }
    public async Task<UserDataDto> GetTokenAsync(LoginDto model)
    {
        UserDataDto userDataDto = new UserDataDto();
        var user = await _unitOfWork.Users
                    .GetByUsernameAsync(model.Name);

        if (user == null)
        {
            userDataDto.IsAuthenticated = false;
            userDataDto.Message = $"User does not exist with username {model.Name}.";
            return userDataDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);

        if (result == PasswordVerificationResult.Success)
        {
            userDataDto.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
            userDataDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            userDataDto.Email = user.Email;
            userDataDto.Name = user.Name;
            userDataDto.Roles = user.Rols
                                            .Select(u => u.Name)
                                            .ToList();

            if (user.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                userDataDto.RefreshToken = activeRefreshToken.Token;
                userDataDto.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                userDataDto.RefreshToken = refreshToken.Token;
                userDataDto.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveAsync();
            }

            return userDataDto;
        }
        userDataDto.IsAuthenticated = false;
        userDataDto.Message = $"Credenciales incorrectas para el usuario {user.Name}.";
        return userDataDto;
    }
    public async Task<string> AddRoleAsync(AddRoleDto model)
    {

        var user = await _unitOfWork.Users
                    .GetByUsernameAsync(model.Name);
        if (user == null)
        {
            return $"User {model.Name} does not exists.";
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);

        if (result == PasswordVerificationResult.Success)
        {
            var rolExists = _unitOfWork.Roles
                                        .Find(u => u.Name.ToLower() == model.Role.ToLower())
                                        .FirstOrDefault();

            if (rolExists != null)
            {
                var userHasRole = user.Rols
                                            .Any(u => u.Id == rolExists.Id);

                if (userHasRole == false)
                {
                    user.Rols.Add(rolExists);
                    _unitOfWork.Users.Update(user);
                    await _unitOfWork.SaveAsync();
                }

                return $"Role {model.Role} added to user {model.Name} successfully.";
            }

            return $"Role {model.Role} was not found.";
        }
        return $"Invalid Credentials";
    }
    public async Task<UserDataDto> RefreshTokenAsync(string refreshToken)
    {
        var userDataDto = new UserDataDto();

        var usuario = await _unitOfWork.Users
                        .GetByRefreshTokenAsync(refreshToken);

        if (usuario == null)
        {
            userDataDto.IsAuthenticated = false;
            userDataDto.Message = $"Token is not assigned to any user.";
            return userDataDto;
        }

        var refreshTokenBd = usuario.RefreshTokens.Single(x => x.Token == refreshToken);

        if (!refreshTokenBd.IsActive)
        {
            userDataDto.IsAuthenticated = false;
            userDataDto.Message = $"Token is not active.";
            return userDataDto;
        }
        //Revoque the current refresh token and
        refreshTokenBd.Revoked = DateTime.UtcNow;
        //generate a new refresh token and save it in the database
        var newRefreshToken = CreateRefreshToken();
        usuario.RefreshTokens.Add(newRefreshToken);
        _unitOfWork.Users.Update(usuario);
        await _unitOfWork.SaveAsync();
        //Generate a new Json Web Token
        userDataDto.IsAuthenticated = true;
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
        userDataDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        userDataDto.Email = usuario.Email;
        userDataDto.Name = usuario.Name;
        userDataDto.Roles = usuario.Rols
                                        .Select(u => u.Name)
                                        .ToList();
        userDataDto.RefreshToken = newRefreshToken.Token;
        userDataDto.RefreshTokenExpiration = newRefreshToken.Expires;
        return userDataDto;
    }
    private RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddDays(10),
                Created = DateTime.UtcNow
            };
        }
    }
    private JwtSecurityToken CreateJwtToken(User usuario)
    {
        var roles = usuario.Rols;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Name));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, usuario.Name),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                                new Claim("uid", usuario.Id.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.HasKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
