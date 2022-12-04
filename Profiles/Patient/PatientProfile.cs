using AutoMapper;

namespace HeroMed_API.Profiles.Patient
{
    public class PatientProfile:Profile
    {
        public PatientProfile()
        {
            CreateMap<Entities.Patient, Models.PatientDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                );
        }
    }
}
