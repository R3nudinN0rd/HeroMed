namespace HeroMed_API.Repositories.Job
{
    public interface IJobRepository
    {
        Task<IEnumerable<Entities.Job>> GetAllJobsAsync();
        Task<Entities.Job> GetJobAsync(Guid jobId);
        void AddJob(Entities.Job job);
        void UpdateJob (Entities.Job job);
    }
}
