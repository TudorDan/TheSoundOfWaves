using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Domain.School, DTOs.School>();
            CreateMap<Domain.Principal, DTOs.Principal>();
        }
    }
}
