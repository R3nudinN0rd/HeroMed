using AutoMapper;
using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using HeroMed_API.Models;
using HeroMed_API.Models.InsertDTOs;
using HeroMed_API.Models.UpdateDTOs;
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
        public async Task<ActionResult<IEnumerable<Models.PatientDTO>>> GetAllPatients()
        {
            var patientsFromRepo = _patientRepository.GetAllPatientsAsync().GetAwaiter().GetResult();
            if(!_validator.ValidateResult(patientsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Patient>>(patientsFromRepo));
        }

        [HttpGet("/id/{patientId}", Name = "GetPatientById")]
        public async Task<ActionResult<Models.PatientDTO>> GetPatientById(Guid patientId)
        {
            if (!_validator.ValidateGuid(patientId))
            {
                return UnprocessableEntity();
            }

            var patientFromRepo = _patientRepository.GetPatientByIdAsync(patientId).GetAwaiter().GetResult();
            if (!_validator.ValidateResult(patientFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PatientDTO>(patientFromRepo));
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

            return Ok(_mapper.Map<PatientDTO>(patientFromRepo));

        }

        [HttpGet("/patientSalon/{salonId}")]
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

            return Ok(_mapper.Map<IEnumerable<PatientDTO>>(patientFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient(InsertPatientDTO patientDTO)
        {
            if (!_validator.ValidatePatientToInsert(patientDTO))
            {
                return UnprocessableEntity();
            }

            var patient = _mapper.Map<Patient>(patientDTO);
            patient.Id = Guid.NewGuid();
            await _patientRepository.AddPatientAsync(patient);

            return CreatedAtRoute("GetPatientById",
                                  new {patientId = patient.Id},
                                  patientDTO);

        }

        [HttpPut("{patientId}")]
        public async Task<ActionResult> UpdatePatient(Guid patientId, UpdatePatientDTO patientDTO)
        {
            if (!_validator.ValidateGuid(patientId))
            {
                return BadRequest();
            }

            if (!_patientRepository.PatientExists(patientId))
            {
                return NotFound();
            }

            var patientFromRepo = _patientRepository.GetPatientByIdAsync(patientId).GetAwaiter().GetResult();

            _mapper.Map(patientDTO, patientFromRepo);
            _patientRepository.UpdatePatient(patientFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(Guid id)
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
