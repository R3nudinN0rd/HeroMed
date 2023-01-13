using AutoMapper;

namespace HeroMed_API.Profiles.PatientEmployee
{
    public class PatientEmployeeProfile:Profile
    {
        public PatientEmployeeProfile()
        {
            CreateMap<Entities.RelationsEntity.PatientEmployee, Models.PatientEmployeeDTO>().ReverseMap();
            CreateMap<Entities.Patient, Models.PatientDTO>().ReverseMap();
            CreateMap<Entities.Employee, Models.EmployeeDTO>().ReverseMap();
        }
    }
}
