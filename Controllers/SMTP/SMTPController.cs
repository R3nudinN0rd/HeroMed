using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TransferServices.SMTP;
using TransferServices.SMTP.Repository;

namespace HeroMed_API.Controllers.SMTP
{
    [ApiController]
    [Route("api/smtp/sendemail")]
    [EnableCors("AllowOrigins")]
    public class SMTPController:ControllerBase
    {
        private readonly IEmailSenderRepository _emailSenderRepository;
        public SMTPController(IEmailSenderRepository emailSenderRepository)
        {
            _emailSenderRepository = emailSenderRepository ?? throw new ArgumentNullException(nameof(emailSenderRepository));
        }

        [HttpPost]
        public ActionResult SendEmail(EmailObject email)
        {
            _emailSenderRepository.SendEmail(email);
           
            return Ok();
        }
    }
}
