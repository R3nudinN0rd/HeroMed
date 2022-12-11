using AutoMapper;
using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using HeroMed_API.Repositories.Patient;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/patient")]
    [EnableCors("AllowOrigins")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validator;
        public PatientController(IMapper mapper, IPatientRepository patientRepository, ControllersInputsValidators validator)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.PatientDTO>> GetAllPatients()
        {
            var patientsFromRepo = _patientRepository.GetAllPatientsAsync().GetAwaiter().GetResult();
            if(!_validator.ValidateResult(patientsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Patient>>(patientsFromRepo));
        }

        [HttpGet("/id/{id}")]
        public ActionResult<Models.PatientDTO> GetPatientById(Guid id)
        {
            if (!_validator.ValidateGuid(id))
            {
                return UnprocessableEntity();
            }

            var patientFromRepo = _patientRepository.GetPatientByIdAsync(id).GetAwaiter().GetResult();
            if (!_validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Patient>(patientFromRepo));
        }

        [HttpGet("/email/{email}")]
        public ActionResult<Models.PatientDTO> GetPatientByEmail(string email)
        {
            if (!_validator.ValidateString(email))
            {
                return UnprocessableEntity();
            }

            var patientFromRepo = _patientRepository.GetPatientByPatientEmailAsync(email).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Patient>(patientFromRepo));

        }

        [HttpGet("/salon/{salonId}")]
        public ActionResult<IEnumerable<Models.PatientDTO>> GetPatientsBySalon(Guid salonId)
        {
            if (!_validator.ValidateGuid(salonId))
            {
                return BadRequest();
            }

            var patientFromRepo = _patientRepository.GetPatientBySalonAsync(salonId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Patient>>(patientFromRepo));
        }

        [HttpPost]
        public ActionResult AddPatient(Patient patient)
        {
            if (!_validator.ValidatePatientToInsert(patient))
            {
                return UnprocessableEntity();
            }
            
            _patientRepository.AddPatient(patient);

            return Ok();

        }

        [HttpDelete("/{id}")]
        public ActionResult DeletePatient(Guid id)
        {
            if (!_validator.ValidateGuid(id))
            {
                return BadRequest();
            }

            _patientRepository.DeletePatient(id);

            return Ok();
        }

    }
}
