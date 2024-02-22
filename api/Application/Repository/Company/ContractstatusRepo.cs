using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Company;
using Domain.Interfaces.Company;
using Persitence.Data;

namespace Application.Repository.Company;

public class ContractstatusRepo : GenericRepository<Contractstatus>, IContractstatus
{
    private readonly ApiClayBioContext _context;

    public ContractstatusRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}