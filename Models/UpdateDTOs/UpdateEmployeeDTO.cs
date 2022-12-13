namespace HeroMed_API.Models.UpdateDTOs
{
    public class UpdateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string BirthPlace { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public Decimal Salary { get; set; }
        public string SalaryCurrency { get; set; }
        public Guid JobId { get; set; }
        public int YearsOfSeniority { get; set; }
    }
}
