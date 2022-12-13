using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroMed_API.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is a required field!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is a required field!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Minimum salary is a required field!")]
        public Decimal MinBruteSalary { get; set; }

        [Required(ErrorMessage = "Maximum salary is a required field!")]
        public Decimal MaxBruteSalary { get; set; }

        [Required(ErrorMessage = "Currency is a required field!")]
        public string Currency { get; set; } 

        [Required(ErrorMessage = "ECTS level is a required field!"), Range(0, 8, ErrorMessage = "ECTS level must be between 0 and 8!")]
        public int MinISCEDLevel { get; set; }

        [Required(ErrorMessage = "Work hours is a required field!"), Range(4, 12, ErrorMessage = "Work hours must be between 4 and 12!")]
        public int WorkHoursPerMonth { get; set; }

        [Required(ErrorMessage = "Paid leave per year is a required field!")]
        public int AnnualPaidLeave { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
