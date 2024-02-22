using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.FPerson;
using Domain.Interfaces.FPerson;
using Persitence.Data;

namespace Application.Repository.FPerson;

public class PersoncategoryRepo : GenericRepository<Personcategory>, IPersoncategory
{
    private readonly ApiClayBioContext _context;

    public PersoncategoryRepo(ApiClayBioContext context) : base(context)
    {
        _context = context;
    }
}