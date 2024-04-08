using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClayBio.Helpers;
using ApiClayBio.Services;
using Application.UnitOfWork;
using Domain.Entities.Authentication;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ApiClayBio.Extensions;

public static class ApplicationServicesExtencions
{
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(Options =>
    {
        Options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()  //.WithOrigins("https://dominio.com")
            .AllowAnyMethod()         //.WithMethods("GET", "POST")
            .AllowAnyHeader());       //.WithHeaders("accept", "content-type")
    });
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        //Configuration from AppSettings
        services.Configure<JWT>(configuration.GetSection("JWT"));

        //Adding Athentication - JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });
    }
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IUserService, UserService>();
    }
}
