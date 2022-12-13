using AutoMapper;

namespace HeroMed_API.Profiles.Job
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Entities.Job, Models.JobDTO>().ReverseMap();
            CreateMap<Entities.Job, Models.InsertDTOs.InsertJobDTO>().ReverseMap();
            CreateMap<Entities.Job, Models.UpdateDTOs.UpdateJobDTO>().ReverseMap();
        }
    }
}
