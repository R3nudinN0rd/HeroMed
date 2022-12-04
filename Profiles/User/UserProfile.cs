using AutoMapper;

namespace HeroMed_API.Profiles.User
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDTO>();
        }
    }
}
