using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Models;
using HeroMed_API.Models.InsertDTOs;
using HeroMed_API.Models.UpdateDTOs;
using HeroMed_API.Repositories.Employee;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    [EnableCors("AllowOrigins")]
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
        public async Task<ActionResult<IEnumerable<Models.EmployeeDTO>>> GetEmployees()
        {
            var employeeFromRepo = _employeeRepository.GetAllEmployeesAsync().GetAwaiter().GetResult();
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employeeFromRepo));
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        public async Task<ActionResult<Models.EmployeeDTO>> GetEmployeeById(Guid employeeId)
        {
            if (!_validators.ValidateGuid(employeeId))
            {
                return BadRequest();
            }
            var employeeFromRepo = _employeeRepository.GetEmployeeByIdAsync(employeeId).GetAwaiter().GetResult();
            if (!_validators.ValidateResult(employeeFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDTO>(employeeFromRepo));
        }
        [HttpGet("emailEmployee/{email}",Name = "GetEmployeeByEmail")]
        public async Task<ActionResult<Models.EmployeeDTO>> GetEmployeeByEmail(string email)
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
        public async Task<ActionResult> CreateEmployee(InsertEmployeeDTO employeeDTO)
        {
           if (!_validators.ValidateEmployeeToInsert(employeeDTO))
           {
               return UnprocessableEntity();
           }
           var employee = _mapper.Map<Employee>(employeeDTO);
            employee.Id = Guid.NewGuid();
            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtRoute("GetEmployeeById",
                                  new { employeeId = employee.Id },
                                  employeeDTO);
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult> UpdateEmployee(Guid employeeId, UpdateEmployeeDTO employee)
        {
            if (!_validators.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employeeFromRepo = _employeeRepository.GetEmployeeByIdAsync(employeeId).GetAwaiter().GetResult();
            _mapper.Map(employee, employeeFromRepo);

            _employeeRepository.UpdateEmployee(employeeFromRepo);

            return NoContent();
        }

        [HttpDelete("id/{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(Guid employeeId)
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
