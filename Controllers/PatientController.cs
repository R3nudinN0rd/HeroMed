using AutoMapper;
using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using HeroMed_API.Repositories.Patient;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators validator;
        public PatientController(IMapper mapper, IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entities.Patient>> GetAllPatients()
        {
            var patientsFromRepo = _patientRepository.GetAllPatientsAsync();
            if(patientsFromRepo == null)
            {
                return NotFound();
            }

            return Ok(patientsFromRepo.GetAwaiter().GetResult());
        }

        [HttpGet("/id/{id}")]
        public ActionResult<Patient> GetPatientById(Guid id)
        {
            if (!validator.ValidateGuid(id))
            {
                return UnprocessableEntity();
            }

            var patientFromRepo = _patientRepository.GetPatientByIdAsync(id).GetAwaiter().GetResult();
            if (!validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok(patientFromRepo);
        }

        [HttpGet("/email/{email}")]
        public ActionResult<Patient> GetPatientByEmail(string email)
        {
            if (!validator.ValidateString(email))
            {
                return UnprocessableEntity();
            }

            var patientFromRepo = _patientRepository.GetPatientByPatientEmailAsync(email).GetAwaiter().GetResult();

            if (!validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok(patientFromRepo);

        }

        [HttpGet("/salon/{salonId}")]
        public ActionResult<IEnumerable<Patient>> GetPatientsBySalon(Guid salonId)
        {
            if (!validator.ValidateGuid(salonId))
            {
                return BadRequest();
            }

            var patientFromRepo = _patientRepository.GetPatientBySalonAsync(salonId).GetAwaiter().GetResult();

            if (!validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult AddPatient(Patient patient)
        {
            if (!validator.ValidatePatientToInsert(patient))
            {
                return UnprocessableEntity();
            }
            
            _patientRepository.AddPatient(patient);

            return Ok();

        }

        [HttpDelete("/{id}")]
        public ActionResult DeletePatient(Guid id)
        {
            if (!validator.ValidateGuid(id))
            {
                return BadRequest();
            }

            _patientRepository.DeletePatient(id);

            return Ok();
        }

    }
}
