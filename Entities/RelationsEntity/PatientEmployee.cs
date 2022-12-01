using System.ComponentModel.DataAnnotations;

namespace HeroMed_API.Entities.RelationsEntity
{
    public class PatientEmployee
    {
        [Required(ErrorMessage = "EmployeeId is a required field!")]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "PatientId is a required field!")]
        public Guid PatientId { get; set; }
        public Employee Employee { get; set; }
        public Patient Patient { get; set; }
    }
}
