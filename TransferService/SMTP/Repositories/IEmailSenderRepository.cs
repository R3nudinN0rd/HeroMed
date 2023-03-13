using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferServices.OAuth2Email.Entities;

namespace TransferServices.OAuth2Email.Repository
{
    public interface IEmailSenderRepository
    {
        public void SendEmail(EmailObject email);
        public string SendVerificationEmail(string email);
    }
}
