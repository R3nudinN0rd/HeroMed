using AutoMapper;

namespace HeroMed_API.Profiles.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entities.Employee, Models.EmployeeDTO>().ReverseMap();
            CreateMap<Entities.Employee, Models.InsertDTOs.InsertEmployeeDTO>().ReverseMap();
            CreateMap<Entities.Employee, Models.UpdateDTOs.UpdateEmployeeDTO>().ReverseMap();
        }
    }
}
