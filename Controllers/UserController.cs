using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Helpers;
using HeroMed_API.Models;
using HeroMed_API.Models.InsertDTOs;
using HeroMed_API.Models.UpdateDTOs;
using HeroMed_API.Repositories.User;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [EnableCors("AllowOrigins")]
    public class UserController : ControllerBase
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

        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<Models.UserDTO>>> GetAllUsers()
        {
            var usersFromRepo = _userRepository.GetAllUsersAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(usersFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.UserDTO>>(usersFromRepo));
        }
        [HttpGet("id/{userId}", Name = "GetUSerById")]
        public async Task<ActionResult<Models.UserDTO>> GetUserById(Guid userId)
        {
            if (!_validator.ValidateGuid(userId))
            {
                return BadRequest();
            }

            var userFromRepo = _userRepository.GetUserByIdAsync(userId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(userFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTO>(userFromRepo));
        }
        [HttpGet("/admins")]
        public async Task<ActionResult<IEnumerable<Models.UserDTO>>> GetAdmins()
        {
            var usersFromRepo = _userRepository.GetAdminsAsync().GetAwaiter().GetResult();

            if (!_validator.ValidateResult(usersFromRepo))
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<Models.UserDTO>>(usersFromRepo));
        }

        [HttpGet("empl/{employeeId}")]
        public async Task<ActionResult<Models.UserDTO>> GetUserByEmplId(Guid employeeId)
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

            return Ok(_mapper.Map<Models.UserDTO>(userFromRepo));
        }

        [HttpGet("email/{userEmail}")]
        public async Task<ActionResult<Models.UserDTO>> GetUserByEmail(string userEmail)
        {
            var userFromRepo = _userRepository.GetUserByEmailAsync(userEmail).GetAwaiter().GetResult();
            if (!_validator.ValidateResult(userFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Models.UserDTO>(userFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(InsertUserDTO userDTO)
        {
            Encryptor crypt = new Encryptor();
            if (!_validator.ValidateUserToInsert(userDTO))
            {
                return UnprocessableEntity();
            }

            var user = _mapper.Map<User>(userDTO);
            user.Id = Guid.NewGuid();
            user.CreatedDate = DateTime.Now;
            user.Admin = false;
            await _userRepository.AddUserAsync(user);

            return CreatedAtRoute("GetUserById",
                                  new { userId = user.Id },
                                  userDTO);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(Guid userId, UpdateUserDTO userDTO)
        {
            if (!_validator.ValidateGuid(userId))
            {
                return BadRequest();
            }

            var userFromRepo = _userRepository.GetUserByIdAsync(userId).GetAwaiter().GetResult();
            _mapper.Map(userDTO, userFromRepo);

            _userRepository.UpdateUser(userFromRepo);
            return NoContent();
        }

        [HttpDelete("email/{email}")]
        public async Task<ActionResult> DeleteUser(string email)
        {
            if(email == "")
            {
                return BadRequest();
            }
            _userRepository.DeleteUserByEmail(email);

            return Ok();
        }

        [HttpDelete("id/{userId}")]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            if (!_validator.ValidateGuid(userId))
            {
                return BadRequest();
            }

            var user = _userRepository.GetUserByIdAsync(userId).GetAwaiter().GetResult();

            if(!_validator.ValidateResult(user))
            {
                return NotFound();
            }

            _userRepository.DeleteUserById(user);

            return NoContent();
        }
    }
}
