using AutoMapper;

namespace HeroMed_API.Profiles.Patient
{
    public class PatientProfile:Profile
    {
        public PatientProfile()
        {
            CreateMap<Entities.Patient, Models.PatientDTO>().ReverseMap();
            CreateMap<Entities.Patient, Models.InsertDTOs.InsertPatientDTO>().ReverseMap();
            CreateMap<Entities.Patient, Models.UpdateDTOs.UpdatePatientDTO>().ReverseMap();
        }
    }
}
