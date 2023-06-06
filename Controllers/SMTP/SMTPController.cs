using AutoMapper;
using HeroMed_API.Repositories.User;
using HeroMed_API.TransferService.SMTP.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SMTPService.Entities;
using SMTPService.Repository;

namespace HeroMed_API.Controllers.SMTP
{
    [ApiController]
    [Route("api/smtp/sendemail")]
    [EnableCors("AllowOrigins")]
    public class SMTPController:ControllerBase
    {
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public SMTPController(IEmailSenderRepository emailSenderRepository, IUserRepository userRepository, IMapper mapper)
        {
            _emailSenderRepository = emailSenderRepository ?? throw new ArgumentNullException(nameof(emailSenderRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public ActionResult SendEmail(EmailObject email)
        {
            _emailSenderRepository.SendEmail(email);
           
            return Ok();
        }

        [HttpPost("verification/send")]
        public ActionResult SendVerificationEmail(PostEmailPayload email)
        {
           var userFromRepo = _userRepository.GetUserForVerification(email.Email).GetAwaiter().GetResult();

            if (userFromRepo == null)
            {
                return NoContent();
            }
            string code = _emailSenderRepository.SendVerificationEmail(email.Email);

            userFromRepo.VerificationCode = code;
            _userRepository.UpdateUser(userFromRepo);
            return NoContent();
        }

        [HttpGet("verification")]
        public ActionResult CheckCode(string email, string code)
        {
            if (code == null || code.Length<6 || code.Length>6)
            {
                return BadRequest();
            }
            var userFromRepo = _userRepository.GetUserForVerification(email, code).GetAwaiter().GetResult();
            if (userFromRepo==null)
            {
                return NoContent();
            }
            userFromRepo.VerificationCode = "";
            _userRepository.UpdateUser(userFromRepo);
            return Ok(_mapper.Map<Models.UserDTO>(userFromRepo));
        }

    }
}
