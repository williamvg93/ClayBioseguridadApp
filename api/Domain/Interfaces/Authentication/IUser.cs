using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Authentication;

namespace Domain.Interfaces.Authentication;

public interface IUser : IGenericRepository<User>
{
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByRefreshTokenAsync(string username);
}