using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.Company;
using ApiClayBio.Dtos.Get.FPerson;
using ApiClayBio.Dtos.Get.Location;
using ApiClayBio.Dtos.Post.Company;
using ApiClayBio.Dtos.Post.FPerson;
using ApiClayBio.Dtos.Post.Location;
using AutoMapper;
using Domain.Entities.Company;
using Domain.Entities.FPerson;
using Domain.Entities.Location;

namespace ApiClayBio.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CountryDto>()
        .ReverseMap();

        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Department, DepartmentPDto>().ReverseMap();

        CreateMap<Town, TownDto>().ReverseMap();
        CreateMap<Town, TownPDto>().ReverseMap();

        CreateMap<Addresstype, AddresstypeDto>().ReverseMap();

        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Address, AddressPDto>().ReverseMap();

        CreateMap<Contacttype, ContacttypeDto>().ReverseMap();

        CreateMap<Personcategory, PersoncategoryDto>().ReverseMap();

        CreateMap<Personcontact, PersoncontactDto>().ReverseMap();
        CreateMap<Personcontact, PersoncontactPDto>().ReverseMap();

        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Person, PersonPDto>().ReverseMap();

        CreateMap<Persontype, PersontypeDto>().ReverseMap();

        CreateMap<Contract, ContractDto>().ReverseMap();
        CreateMap<Contract, ContractPDto>().ReverseMap();

        CreateMap<Contractstatus, ContractstatusDto>().ReverseMap();

        CreateMap<Shiftscheduling, ShiftschedulingDto>().ReverseMap();

        CreateMap<Workshift, WorkshiftDto>().ReverseMap();
    }
}