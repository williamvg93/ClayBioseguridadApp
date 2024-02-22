using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Company;
using Domain.Interfaces.Company;
using Persitence.Data;

namespace Application.Repository.Company;


public class ShiftschedulingRepo : GenericRepository<Shiftscheduling>, IShiftscheduling
{
    private readonly ApiClayBioContext _context;

    public ShiftschedulingRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}