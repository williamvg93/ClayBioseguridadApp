using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Company;
using Domain.Interfaces.FPerson;
using Domain.Interfaces.Location;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IAddress Addresses { get; }
    IAddresstype Addresstypes { get; }
    ICountry Countries { get; }
    IDepartment Departments { get; }
    ITown Towns { get; }
    IContacttype Contacttypes { get; }
    IPerson People { get; }
    IPersoncategory Personcategories { get; }
    IPersoncontact Personcontacts { get; }
    IPersontype Persontypes { get; }
    IContract Contracts { get; }
    IContractstatus Contractsstatus { get; }
    IShiftscheduling Shiftschedulings { get; }
    IWorkshift Workshifts { get; }
    Task<int> SaveAsync();
}