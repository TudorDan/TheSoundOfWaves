using AutoMapper;

namespace E_LearningSite.API.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Domain.School, Models.School>();

            CreateMap<Domain.Principal, Models.Principal>();

            CreateMap<Domain.Mentor, Models.Mentor>();

            CreateMap<Domain.Student, Models.Student>();

            CreateMap<Domain.Course, Models.Course>();

            CreateMap<Domain.Document, Models.Document>();

            CreateMap<Domain.Subject, Models.Subject>();
        }
    }
}
