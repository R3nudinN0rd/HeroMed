using AutoMapper;
using HeroMed_API.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet,HttpHead]
        public ActionResult<IEnumerable<Entities.User>> GertAllUsers()
        {
            var usersFromRepo = _userRepository.GetAllUsersAsync();
            return Ok(usersFromRepo.GetAwaiter().GetResult());
        }

        [HttpGet("/admins")]
        public ActionResult<IEnumerable<Entities.User>> GetAdmins()
        {
            var usersFromRepo = _userRepository.GetAdminsAsync();
            return Ok(usersFromRepo.GetAwaiter().GetResult());
        }

        [HttpGet("/{employeeId}")]
        public ActionResult<Entities.User> GetUserByEmplId(Guid employeeId)
        {
            var userFromRepo = _userRepository.GetUserByEmployeeId(employeeId);
            if(userFromRepo == null)
            {
                return NotFound();
            }

            return Ok(userFromRepo.GetAwaiter().GetResult());
        }

        [HttpPost]
        public ActionResult AddUser(Entities.User user)
        {
            if(user == null)
            {
                return BadRequest();
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
