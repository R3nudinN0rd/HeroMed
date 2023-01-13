using System.ComponentModel.DataAnnotations;

namespace HeroMed_API.Models.InsertDTOs
{
    public class InsertJobDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal MinBruteSalary { get; set; }
        public Decimal MaxBruteSalary { get; set; }
        public string Currency { get; set; }
        public int MinISCEDLevel { get; set; }
        public int WorkHoursPerMonth { get; set; }
        public int AnnualPaidLeave { get; set; }
    }
}
