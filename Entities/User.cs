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

        [Required(ErrorMessage = "Email is a required field!")]
        public string Email { get; set; }
        public string? VerificationCode { get; set; }

        [Required(ErrorMessage = "Created date is a required field!")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Admin is a required field!"), DefaultValue(false)]
        public bool Admin { get; set; }

        public Employee AccountOf { get; set; }

        [ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }

    }
}
