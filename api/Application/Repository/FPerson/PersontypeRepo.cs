using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Domain.Interfaces.FPerson;
using Persitence.Data;

namespace Application.Repository.FPerson;

public class PersontypeRepo : GenericRepository<Persontype>, IPersontype
{
    private readonly ApiClayBioContext _context;

    public PersontypeRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}