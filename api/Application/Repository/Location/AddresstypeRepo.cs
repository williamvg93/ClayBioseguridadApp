using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persitence.Data;

namespace Application.Repository.Location;

public class AddresstypeRepo : GenericRepository<Addresstype>, IAddresstype
{
    private readonly ApiClayBioContext _context;

    public AddresstypeRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}