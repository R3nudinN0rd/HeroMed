using AutoMapper;

namespace HeroMed_API.Profiles.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entities.Employee, Models.EmployeeDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
