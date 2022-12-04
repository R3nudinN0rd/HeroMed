using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Repositories.Job;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    public class JobController:ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper; 
        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet, HttpHead]
        public ActionResult<IEnumerable<Entities.Job>> GetAllJobs()
        {
            var jobsFromRepo = _jobRepository.GetAllJobsAsync();
            if(jobsFromRepo == null)
            {
                return NotFound();
            }
            return Ok(jobsFromRepo.GetAwaiter().GetResult());
        }

        [HttpGet("/{jobId}")]
        public ActionResult<Entities.Job> GetJobById(Guid jobId)
        {            
            var jobFromRepo = _jobRepository.GetJobAsync(jobId);
            
            if(jobFromRepo == null)
            {
                return NotFound();
            }

            return Ok(jobFromRepo.GetAwaiter().GetResult());
        }

        [HttpPost]
        public ActionResult AddJob(Entities.Job job)
        {
            _jobRepository.AddJob(job);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateJob(Entities.Job job)
        {
            _jobRepository.UpdateJob(job);
            return Ok();
        }
    }
}
