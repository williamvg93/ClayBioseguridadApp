using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository.Company;
using Application.Repository.FPerson;
using Application.Repository.Location;
using Domain.Interfaces;
using Domain.Interfaces.Company;
using Domain.Interfaces.FPerson;
using Domain.Interfaces.Location;
using Persitence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiClayBioContext _context;
    private IAddress _addresses;
    private IAddresstype _addresstypes;
    private ICountry _countries;
    private IDepartment _departments;
    private ITown _towns;
    private IContacttype _contacttypes;
    private IPerson _people;
    private IPersoncategory _personcategories;
    private IPersoncontact _personcontacts;
    private IPersontype _persontypes;
    private IContract _contracts;
    private IContractstatus _contractsstatus;
    private IShiftscheduling _shiftschedulings;
    private IWorkshift _workshifts;


    public UnitOfWork(ApiClayBioContext context)
    {
        _context = context;
    }

    public IAddress Addresses
    {
        get
        {
            if (_addresses == null)
            {
                _addresses = new AddressRepo(_context);
            }
            return _addresses;
        }
    }

    public IAddresstype Addresstypes
    {
        get
        {
            if (_addresstypes == null)
            {
                _addresstypes = new AddresstypeRepo(_context);
            }
            return _addresstypes;
        }
    }

    public ICountry Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepo(_context);
            }
            return _countries;
        }
    }

    public IDepartment Departments
    {
        get
        {
            if (_departments == null)
            {
                _departments = new DepartmentRepo(_context);
            }
            return _departments;
        }
    }

    public ITown Towns
    {
        get
        {
            if (_towns == null)
            {
                _towns = new TownRepo(_context);
            }
            return _towns;
        }
    }

    public IContacttype Contacttypes
    {
        get
        {
            if (_contacttypes == null)
            {
                _contacttypes = new ContacttypeRepo(_context);
            }
            return _contacttypes;
        }
    }

    public IPerson People
    {
        get
        {
            if (_people == null)
            {
                _people = new PersonRepo(_context);
            }
            return _people;
        }
    }

    public IPersoncategory Personcategories
    {
        get
        {
            if (_personcategories == null)
            {
                _personcategories = new PersoncategoryRepo(_context);
            }
            return _personcategories;
        }
    }

    public IPersoncontact Personcontacts
    {
        get
        {
            if (_personcontacts == null)
            {
                _personcontacts = new PersoncontactRepo(_context);
            }
            return _personcontacts;
        }
    }

    public IPersontype Persontypes
    {
        get
        {
            if (_persontypes == null)
            {
                _persontypes = new PersontypeRepo(_context);
            }
            return _persontypes;
        }
    }

    public IContract Contracts
    {
        get
        {
            if (_contracts == null)
            {
                _contracts = new ContractRepo(_context);
            }
            return _contracts;
        }
    }

    public IContractstatus Contractsstatus
    {
        get
        {
            if (_contractsstatus == null)
            {
                _contractsstatus = new ContractstatusRepo(_context);
            }
            return _contractsstatus;
        }
    }

    public IShiftscheduling Shiftschedulings
    {
        get
        {
            if (_shiftschedulings == null)
            {
                _shiftschedulings = new ShiftschedulingRepo(_context);
            }
            return _shiftschedulings;
        }
    }

    public IWorkshift Workshifts
    {
        get
        {
            if (_workshifts == null)
            {
                _workshifts = new WorkshiftRepo(_context);
            }
            return _workshifts;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}