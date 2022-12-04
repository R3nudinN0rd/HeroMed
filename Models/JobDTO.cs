namespace HeroMed_API.Models
{
    public class JobDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal MinSalary { get; set; }
        public Decimal MaxSalary { get; set; }
        public string Currency { get; set; }
        public int AnnualPaidLeave { get; set; }
    }
}
