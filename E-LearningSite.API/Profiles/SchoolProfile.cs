using AutoMapper;

namespace E_LearningSite.API.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Domain.School, DTOs.School>();
            CreateMap<Domain.Principal, DTOs.Principal>();
            CreateMap<Domain.Mentor, DTOs.Mentor>();
            CreateMap<Domain.Student, DTOs.Student>();
            CreateMap<Domain.Course, DTOs.Course>();
            CreateMap<Domain.Document, DTOs.Document>();
            CreateMap<Domain.Subject, DTOs.Subject>();
        }
    }
}
