using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.Location;
using AutoMapper;
using Domain.Entities.Location;

namespace ApiClayBio.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CountryDto>()
        .ReverseMap();
    }
}