using AutoMapper;
using HeroMed_API.Repositories.Employee;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet, HttpHead]
        public ActionResult<IEnumerable<Entities.Employee>> GetEmployees()
        {
            var employeeFromRepo = _employeeRepository.GetAllEmployeesAsync();
            return Ok(employeeFromRepo.GetAwaiter().GetResult());
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(Guid employeeId)
        {
            var employeeFromRepo = _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if(employeeFromRepo == null)
            {
                return NotFound();
            }

            return Ok(employeeFromRepo.GetAwaiter().GetResult());
        }
        [HttpGet("/email/{employeeEmail}",Name = "GetEmployeeByEmail")]
        public IActionResult GetEmployeeByEmail(string email)
        {
            var employeeFromRepo = _employeeRepository.GetEmployeeByEmailAsync(email);
            if(employeeFromRepo == null)
            {
                return NotFound();
            }
            return Ok(employeeFromRepo.GetAwaiter().GetResult());

        }

        [HttpPost]
        public ActionResult CreateEmployee(Entities.Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return CreatedAtRoute("GetEmployeeById",
                                  new { employeeId = employee.Id });
        }

        [HttpDelete("id/{employeeId}")]
        public ActionResult DeleteEmployee(Guid employeeId)
        {
            var employeeFromRepo =  _employeeRepository.GetEmployeeByIdAsync(employeeId).Result;
            if(employeeFromRepo == null)
            {
                return NotFound();
            }
            _employeeRepository.DeleteEmployee(employeeFromRepo);

            return NoContent();
        }
    }
}
