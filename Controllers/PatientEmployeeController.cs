using AutoMapper;
using HeroMed_API.Entities.RelationsEntity;
using HeroMed_API.Repositories.PatientEmployee;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/relation")]
    public class PatientEmployeeController:ControllerBase
    {
        private readonly IPatientEmployeeRepository _patientEmployeeRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validator;

        public PatientEmployeeController(IPatientEmployeeRepository patientEmployeeRepository, IMapper mapper, ControllersInputsValidators validator)
        {
            _patientEmployeeRepository = patientEmployeeRepository ?? throw new ArgumentNullException(nameof(patientEmployeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<Models.PatientEmployeeDTO>>> GetAllRelationsAsync()
        {
            var relationsFromRepo = _patientEmployeeRepository.GetPatientEmployeeRelationsAsync().GetAwaiter().GetResult();
            if (relationsFromRepo.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<Models.PatientEmployeeDTO>>(relationsFromRepo));
        }

        [HttpGet("/relationP/{patientId}")]
        public async Task<ActionResult<IEnumerable<Models.PatientEmployeeDTO>>> GetRelationsByPatientId(Guid patientId)
        {
            if (!_validator.ValidateGuid(patientId))
            {
                return BadRequest();
            }

            var relationsFromRepo = _patientEmployeeRepository.GetPatientEmployeesRelationsAsync(patientId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(relationsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.PatientEmployeeDTO>>(relationsFromRepo));
        }

        [HttpGet("/relationE/{employeeId}")]
        public async Task<ActionResult<IEnumerable<Models.PatientEmployeeDTO>>> GetRelationsByEmployeeId(Guid employeeId)
        {
            if (!_validator.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            var relationsFromRepo = _patientEmployeeRepository.GetEmployeePatientsRelationsAsync(employeeId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(relationsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.PatientEmployeeDTO>>(relationsFromRepo));
        }

        [HttpGet("/relation/{employeeId}/{patientId}", Name = "GetRelationByKey")]
        public ActionResult<Models.PatientEmployeeDTO> GetSpecificRelation(Guid patientId, Guid employeeId)
        {
            if(!_validator.ValidateGuid(patientId) || !_validator.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            var relationFromRepo = _patientEmployeeRepository.GetRelationAsync(employeeId, patientId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(relationFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Models.PatientEmployeeDTO>(relationFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult> AddRelation(Models.PatientEmployeeDTO relationDTO)
        {
            if (!_validator.ValidateRelationToInsert(relationDTO))
            {
                return UnprocessableEntity();
            }

            var relation = _mapper.Map<PatientEmployee>(relationDTO);
            await _patientEmployeeRepository.AddRelationAsync(relation);

            return CreatedAtRoute("GetRelationByKey",
                                   new { employeeId = relation.EmployeeId,patientId = relation.PatientId },
                                   relationDTO) ;
        }

        [HttpPut("employee/{employeeId}/patient/{patientId}")]
        public async Task<ActionResult> UpdateRelation(Guid employeeId, Guid patientId, Models.PatientEmployeeDTO relationDTO)
        {
            if(!_validator.ValidateGuid(employeeId) || !_validator.ValidateGuid(patientId))
            {
                return BadRequest();
            }
            if (!_validator.ValidateRelationToInsert(relationDTO))
            {
                return UnprocessableEntity();
            }

            if(!_patientEmployeeRepository.RelationExists(employeeId, patientId))
            {
                return NotFound();
            }

            var relationFromRepo = _patientEmployeeRepository.GetRelationAsync(employeeId, patientId).GetAwaiter().GetResult();
            _mapper.Map(relationDTO, relationFromRepo);
            _patientEmployeeRepository.UpdateRelation(relationFromRepo);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRelation(Guid employeeId, Guid patientId)
        {
            if(!_validator.ValidateGuid(employeeId) || !_validator.ValidateGuid(patientId))
            {
                return BadRequest();
            }

            _patientEmployeeRepository.DeleteRelation(employeeId, patientId);

            return Ok();
        }
    }
}
