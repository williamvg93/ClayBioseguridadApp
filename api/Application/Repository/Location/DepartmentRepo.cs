using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persitence.Data;

namespace Application.Repository.Location;

public class DepartmentRepo : GenericRepository<Department>, IDepartment
{
    private readonly ApiClayBioContext _context;

    public DepartmentRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}