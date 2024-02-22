using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Domain.Interfaces.FPerson;
using Persitence.Data;

namespace Application.Repository.FPerson;

public class PersoncontactRepo : GenericRepository<Personcontact>, IPersoncontact
{
    private readonly ApiClayBioContext _context;

    public PersoncontactRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}