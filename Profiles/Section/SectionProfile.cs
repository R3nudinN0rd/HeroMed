using AutoMapper;

namespace HeroMed_API.Profiles.Section
{
    public class SectionProfile:Profile
    {
        public SectionProfile()
        {
            CreateMap<Entities.Section, Models.SalonDTO>();
        }
    }
}
