using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroMed_API.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Username is a required field!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is a required field!"), PasswordPropertyText]
        public string Password { get; set; }
        [Required(ErrorMessage = "Created date is a required field!")]
        public DateTimeOffset CreatedDate { get; set; }
        [Required(ErrorMessage = "Admin is a required field!"), DefaultValue(false)]
        public bool Admin { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee AccountOf { get; set; }
        public Guid EmployeeId { get; set; }

    }
}
