using AutoMapper;

namespace HeroMed_API.Profiles.User
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDTO>().ReverseMap();
            CreateMap<Entities.User, Models.InsertDTOs.InsertUserDTO>().ReverseMap();
            CreateMap<Entities.User, Models.UpdateDTOs.UpdateUserDTO>().ReverseMap();
        }
    }
}
