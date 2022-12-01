using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.Repositories.Job
{
    public class JobRepository : IJobRepository
    {
        private readonly HeroMedContext _context;

        public JobRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Entities.Job> GetJobAsync(Guid jobId)
        {
            return await _context.Jobs.FirstOrDefaultAsync<Entities.Job>(job => job.Id == jobId);
        }

        public void UpdateJob(Entities.Job job)
        {
            try
            {
                _context.Jobs.Update(job);
                _context.SaveChanges();
            }
            catch (ArgumentNullException) 
            {
                throw new ArgumentNullException(nameof(job));
            }
        }
    }
}
