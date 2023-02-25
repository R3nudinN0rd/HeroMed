namespace HeroMed_API.Repositories.Job
{
    public interface IJobRepository
    {
        Task<IEnumerable<Entities.Job>> GetAllJobsAsync();
        Task<Entities.Job> GetJobAsync(Guid jobId);
        Task<Entities.Job> AddJobAsync(Entities.Job job);
        void UpdateJob (Entities.Job job);
        void DeleteJob(Entities.Job jobID);
        bool JobExists(Guid jobId);
    }
}
