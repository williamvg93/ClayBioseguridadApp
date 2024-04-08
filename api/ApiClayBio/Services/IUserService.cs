using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Post.Authentication;

namespace ApiClayBio.Services;

public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<UserDataDto> GetTokenAsync(LoginDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
    Task<UserDataDto> RefreshTokenAsync(string refreshToken);
}
