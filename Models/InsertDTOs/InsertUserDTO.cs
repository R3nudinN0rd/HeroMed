using HeroMed_API.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HeroMed_API.Models.InsertDTOs
{
    public class InsertUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
