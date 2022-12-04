using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Repositories.Job;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    public class JobController:ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validator;
        public JobController(IJobRepository jobRepository, IMapper mapper, ControllersInputsValidators validator)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet, HttpHead]
        public ActionResult<IEnumerable<Entities.Job>> GetAllJobs()
        {
            var jobsFromRepo = _jobRepository.GetAllJobsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(jobsFromRepo))
            {
                return NotFound();
            }
            return Ok(jobsFromRepo);
        }

        [HttpGet("/{jobId}")]
        public ActionResult<Entities.Job> GetJobById(Guid jobId)
        {
            if (!_validator.ValidateGuid(jobId))
            {
                return BadRequest();
            }
            var jobFromRepo = _jobRepository.GetJobAsync(jobId).GetAwaiter().GetResult();
            
            if(!_validator.ValidateResult(jobFromRepo))
            {
                return NotFound();
            }

            return Ok(jobFromRepo);
        }

        [HttpPost]
        public ActionResult AddJob(Entities.Job job)
        {
            if (!_validator.ValidateJobToInsert(job))
            {
                return UnprocessableEntity();
            }

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
