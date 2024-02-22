using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Domain.Interfaces.FPerson;
using Persitence.Data;

namespace Application.Repository.FPerson;

public class PersonRepo : GenericRepository<Person>, IPerson
{
    private readonly ApiClayBioContext _context;

    public PersonRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}