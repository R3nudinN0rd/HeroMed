using HeroMed_API.Entities.RelationsEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroMed_API.Entities
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is a required field!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is a required field!")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Address is a required field!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is a required field!"), EmailAddress(ErrorMessage = "Wrong email format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is a required field!"), Phone(ErrorMessage = "Phone number format invalid!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Emargency contact name is a required field!")]
        public string EmergencyContactName { get; set; }

        [Required(ErrorMessage = "Emergency contact phone number is a required field!"), Phone(ErrorMessage = "Phone number format invalid!")]
        public string EmergencyContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "Salon is a required field!")]
        public Salon Salon { get; set; }
        public Guid SalonId { get; set; }

        [Required(ErrorMessage = "Issue details is a required field!")]
        public string IssueDetails { get; set; }

        [Required(ErrorMessage = "Enroled date is a required field!")]
        public DateTime EnrolledDate { get; set; }

        [Required(ErrorMessage = "Discharge date is a required field!")]
        public DateTime DischargeDate { get; set; }
        public ICollection<PatientEmployee> PatientEmployees { get; set; }
    }
}
