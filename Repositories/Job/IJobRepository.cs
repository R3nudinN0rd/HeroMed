namespace HeroMed_API.Repositories.Job
{
    public interface IJobRepository
    {
        Task<IEnumerable<Entities.Job>> GetAllJobsAsync();
        Task<Entities.Job> GetJobAsync(Guid jobId);
        void UpdateJob (Entities.Job job);
    }
}
