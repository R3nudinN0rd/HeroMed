using AutoMapper;
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
        public ActionResult<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetAllRelationsAsync()
        {
            var relationsFromRepo = _patientEmployeeRepository.GetPatientEmployeeRelationsAsync().GetAwaiter().GetResult();
            if (relationsFromRepo.Count() == 0)
            {
                return NotFound();
            }
            return Ok(relationsFromRepo);
        }

        [HttpGet("/patients/{employeeId}")]
        public ActionResult<IEnumerable<Models.PatientDTO>> GetPatientsByEmployeeId(Guid employeeId)
        {
            if (!_validator.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            var patientsFromRepo = _patientEmployeeRepository.GetEmployeePatientsAsync(employeeId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(patientsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Entities.Patient>(patientsFromRepo));

        }

        [HttpGet("/employee/{patientId}")]
        public ActionResult<IEnumerable<Models.EmployeeDTO>> GetEmployeesByPatientId(Guid patientId)
        {
            if (!_validator.ValidateGuid(patientId))
            {
                return BadRequest();
            }

            var employeeFromRepo = _patientEmployeeRepository.GetPatientEmployeeAsync(patientId).GetAwaiter().GetResult();

            if (_validator.ValidateResult(employeeFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Entities.Employee>(employeeFromRepo));
        }

        [HttpGet("/relationP/{patientId}")]
        public ActionResult<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetRelationsByPatientId(Guid patientId)
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

            return Ok(relationsFromRepo);
        }

        [HttpGet("/relationE/{employeeId}")]
        public ActionResult<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetRelationsByEmployeeId(Guid employeeId)
        {
            if (!_validator.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            var relationsFromRepo = _patientEmployeeRepository.GetEmployeePatientsAsync(employeeId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(relationsFromRepo))
            {
                return NotFound();
            }

            return Ok(relationsFromRepo);
        }

        [HttpGet("/relation/{employeeId}/{patientId}")]
        public ActionResult<Entities.RelationsEntity.PatientEmployee> GetSpecificRelation(Guid patientId, Guid employeeId)
        {
            if(!_validator.ValidateGuid(patientId) || !_validator.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            var relationFromRepo = _patientEmployeeRepository.GetRelation(employeeId, patientId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(relationFromRepo))
            {
                return NotFound();
            }

            return Ok(relationFromRepo);
        }

        [HttpPost]
        public ActionResult AddRelation(Entities.RelationsEntity.PatientEmployee relation)
        {
            if (!_validator.ValidateRelationToInsert(relation))
            {
                return UnprocessableEntity();
            }

            _patientEmployeeRepository.AddRelation(relation);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateRelation(Entities.RelationsEntity.PatientEmployee relation)
        {
            if (!_validator.ValidateRelationToInsert(relation))
            {
                return UnprocessableEntity();
            }

            _patientEmployeeRepository.UpdateRelation(relation);

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteRelation(Guid employeeId, Guid patientId)
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
