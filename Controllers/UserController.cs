using AutoMapper;
using HeroMed_API.Repositories.User;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validator;

        public UserController(IUserRepository userRepository, IMapper mapper, ControllersInputsValidators validator)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet,HttpHead]
        public ActionResult<IEnumerable<Models.UserDTO>> GetAllUsers()
        {
            var usersFromRepo = _userRepository.GetAllUsersAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(usersFromRepo))
            {
                return NotFound(); ;
            }

            return Ok(_mapper.Map<IEnumerable<Entities.User>>(usersFromRepo));
        }

        [HttpGet("/admins")]
        public ActionResult<IEnumerable<Models.UserDTO>> GetAdmins()
        {
            var usersFromRepo = _userRepository.GetAdminsAsync().GetAwaiter().GetResult();

            if(!_validator.ValidateResult(usersFromRepo))
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<Entities.User>>(usersFromRepo));
        }

        [HttpGet("/empl/{employeeId}")]
        public ActionResult<Models.UserDTO> GetUserByEmplId(Guid employeeId)
        {
            if (!_validator.ValidateGuid(employeeId))
            {
                return BadRequest();
            }

            var userFromRepo = _userRepository.GetUserByEmployeeId(employeeId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(userFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Entities.User>(userFromRepo));
        }

        [HttpPost]
        public ActionResult AddUser(Entities.User user)
        {
            if(!_validator.ValidateUserToInsert(user))
            {
                return UnprocessableEntity();
            }

            _userRepository.AddUser(user);

            return Ok(user);
        }

        [HttpPut]
        public ActionResult UpdateUser(Entities.User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            _userRepository.UpdateUser(user);

            return Ok(user);
        }

        [HttpDelete("/{username}")]
        public ActionResult DeleteUser(string username)
        {
            if(username == null)
            {
                return BadRequest();
            }
            _userRepository.DeleteUserByUsername(username);

            return Ok();
        }
    }
}
