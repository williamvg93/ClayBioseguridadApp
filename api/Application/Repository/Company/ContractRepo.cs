using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Company;
using Domain.Interfaces.Company;
using Persitence.Data;

namespace Application.Repository.Company;

public class ContractRepo : GenericRepository<Contract>, IContract
{
    private readonly ApiClayBioContext _context;

    public ContractRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}