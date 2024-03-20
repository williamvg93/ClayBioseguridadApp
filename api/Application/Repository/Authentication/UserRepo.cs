using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Authentication;
using Domain.Interfaces.Authentication;
using Microsoft.EntityFrameworkCore;
using Persitence.Data;

namespace Application.Repository.Authentication;

public class UserRepo : GenericRepository<User>, IUser
{
    private readonly ApiClayBioContext _context;

    public UserRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Rols)
            /*  .Include(u => u.RefreshTokens) */
            .FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());
    }

    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }
}