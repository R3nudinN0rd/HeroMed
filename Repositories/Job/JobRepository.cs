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

        public bool JobExists(Guid jobId)
        {
            if(_context.Jobs.FirstOrDefault(job => job.Id == jobId) == null){
                return false;
            }

            return true;
        }

        public void AddJob(Entities.Job job)
        {
            try
            {
                _context.Jobs.Add(job);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(job));
            }
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

        public void DeleteJob(Entities.Job job)
        {
            try
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception(nameof(job));
            }
        }
    }
}
