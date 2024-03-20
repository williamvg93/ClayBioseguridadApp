using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Authentication;
using Domain.Interfaces.Authentication;
using Persitence.Data;

namespace Application.Repository.Authentication;
public class RolRepo : GenericRepository<Rol>, IRol
{
    private readonly ApiClayBioContext _context;

    public RolRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}