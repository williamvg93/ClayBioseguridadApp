using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;

namespace Domain.Interfaces.Location;

public interface ICountry : IGenericRepository<Country>
{
}