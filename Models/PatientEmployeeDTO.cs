using System.ComponentModel.DataAnnotations;

namespace HeroMed_API.Models
{
    public class PatientEmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        public Guid PatientId { get; set; }
    }
}
