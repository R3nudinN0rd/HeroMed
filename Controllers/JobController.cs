using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Models;
using HeroMed_API.Models.InsertDTOs;
using HeroMed_API.Models.UpdateDTOs;
using HeroMed_API.Repositories.Job;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    [EnableCors("AllowOrigins")]
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
        public async Task<ActionResult<IEnumerable<Models.JobDTO>>> GetAllJobs()
        {
            var jobsFromRepo = _jobRepository.GetAllJobsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(jobsFromRepo))
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<JobDTO>>(jobsFromRepo));
        }

        [HttpGet("/job/{jobId}", Name = "GetJobById")]
        public async Task<ActionResult<Models.JobDTO>> GetJobById(Guid jobId)
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

            return Ok(_mapper.Map<JobDTO>(jobFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult> AddJob(InsertJobDTO jobDTO)
        {
            if (!_validator.ValidateJobToInsert(jobDTO))
            {
                return UnprocessableEntity();
            }
            var job = _mapper.Map<Job>(jobDTO);
            job.Id = Guid.NewGuid();
            await _jobRepository.AddJobAsync(job);
            return CreatedAtRoute("GetJobById",
                                   new { jobId = job.Id},
                                   jobDTO);
        }

        [HttpPut("{jobId}")]
        public async Task<ActionResult> UpdateJob(Guid jobId, UpdateJobDTO jobDTO)
        {
            if (!_validator.ValidateGuid(jobId))
            {
                return BadRequest();
            }

            if (!_jobRepository.JobExists(jobId)){
                return NotFound();
            }

            var jobFromRepo = _jobRepository.GetJobAsync(jobId).GetAwaiter().GetResult();

            _mapper.Map(jobDTO, jobFromRepo);
            _jobRepository.UpdateJob(jobFromRepo);
            return NoContent();
        }

        [HttpDelete("{jobId}")]
        public async Task<ActionResult> DeleteJob(Guid jobId)
        {
            if (!_validator.ValidateGuid(jobId))
            {
                return BadRequest();
            }

            var jobFromRepo = _jobRepository.GetJobAsync(jobId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(jobFromRepo))
            {
                return NotFound();
            }

            _jobRepository.DeleteJob(jobFromRepo);

            return NoContent();
        }
    }
}
