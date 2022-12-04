using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Repositories.Employee;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validators;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, ControllersInputsValidators validator)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validators = validator ?? throw new ArgumentNullException(nameof(validator));
        }


        [HttpGet, HttpHead]
        public ActionResult<IEnumerable<Models.EmployeeDTO>> GetEmployees()
        {
            var employeeFromRepo = _employeeRepository.GetAllEmployeesAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<Employee>>(employeeFromRepo));
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        public ActionResult<Models.EmployeeDTO> GetEmployeeById(Guid employeeId)
        {
            if (_validators.ValidateGuid(employeeId))
            {
                return BadRequest();
            }
            var employeeFromRepo = _employeeRepository.GetEmployeeByIdAsync(employeeId).GetAwaiter().GetResult();
            if (!_validators.ValidateResult(employeeFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Employee>(employeeFromRepo));
        }
        [HttpGet("/email/{employeeEmail}",Name = "GetEmployeeByEmail")]
        public ActionResult<Models.EmployeeDTO> GetEmployeeByEmail(string email)
        {
            if (!_validators.ValidateString(email))
            {
                return BadRequest();
            }
            var employeeFromRepo = _employeeRepository.GetEmployeeByEmailAsync(email).GetAwaiter().GetResult();
            
            if(!_validators.ValidateResult(employeeFromRepo))
            if(!_validators.ValidateResult(employeeFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Employee>(employeeFromRepo));

        }

        [HttpPost]
        public ActionResult CreateEmployee(Entities.Employee employee)
        {
            if (!_validators.ValidateEmployeeToInsert(employee))
            {
                return UnprocessableEntity();
            }

            _employeeRepository.AddEmployee(employee);
            return CreatedAtRoute("GetEmployeeById",
                                  new { employeeId = employee.Id });
        }

        [HttpDelete("id/{employeeId}")]
        public ActionResult DeleteEmployee(Guid employeeId)
        {
            if (!_validators.ValidateGuid(employeeId))
            {
                return BadRequest();
            }
            var employeeFromRepo =  _employeeRepository.GetEmployeeByIdAsync(employeeId).Result;

            if (!_validators.ValidateResult(employeeFromRepo))
            {
                return NotFound();
            }

            _employeeRepository.DeleteEmployee(employeeFromRepo);

            return NoContent();
        }
    }
}
