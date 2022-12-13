namespace HeroMed_API.Models.UpdateDTOs
{
    public class UpdateJobDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal MinBruteSalary { get; set; }
        public Decimal MaxBruteSalary { get; set; }
    }
}
