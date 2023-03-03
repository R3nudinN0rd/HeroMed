using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TransferServices.OAuth2Email.Entities;

namespace TransferServices.OAuth2Email.Repository
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        public void SendEmail(EmailObject email)
        {
            SendEmailOAuth(email);
        }

        public string SendVerificationEmail(string email)
        {
            string code = GenerateCode();
            EmailObject _email = new EmailObject();
            _email.Subject = "HeroMed System authentication";
            _email.Recipients.Add(email);
            _email.Body = "Your verification code is: [" + code + "]";
            _email.IsHtml = true;

            SendEmail(_email);
            return code;
        }


        private bool SendEmailOAuth(EmailObject email)
        {
            string recipients = "";
            foreach (var recipient in email.Recipients)
            {
                recipients += recipient + ";";
            }
            try
            {
                string[] Scopes = { GmailService.Scope.GmailSend };
                UserCredential credential;
                using (var stream = new FileStream(
                    @"../CommunicationServices/Resources/client_secret.json",
                    FileMode.Open,
                    FileAccess.Read
                ))
                {
                    string credPath = "token_Send.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                 GoogleClientSecrets.FromStream(stream).Secrets,
                                  Scopes,
                                  "user",
                                  CancellationToken.None,
                                  new FileDataStore(credPath, true)).Result;
                    //Console.WriteLine("Credential file saved to: " + credPath);
                }
                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "HeroMed",
                });
                //Parsing HTML 
                string message = $"To: {recipients}\r\nSubject: {email.Subject}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n{email.Body}";
                var newMsg = new Message();
                newMsg.Raw = Base64UrlEncode(message.ToString());
                Message response = service.Users.Messages.Send(newMsg, "me").Execute();

                if (response != null)
                    return true;
                else
                    return false;
            }
            catch (SmtpException e)
            {
                throw e;
            }
        }

        private string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }

        private string GenerateCode()
        {
            Random random = new Random();
            string code = random.Next(100000, 999999).ToString();

            return code;
        }


    }
}
