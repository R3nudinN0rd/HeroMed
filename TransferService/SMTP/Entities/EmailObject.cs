using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferServices.OAuth2Email.Entities
{
    public class EmailObject
    {
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public EmailObject()
        {
            Recipients = new List<string>();
        }
    }
}
