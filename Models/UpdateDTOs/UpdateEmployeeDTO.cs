namespace HeroMed_API.Models.UpdateDTOs
{
    public class UpdateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid JobId { get; set; }
        public Guid SectionId { get; set; }
        public int YearsOfSeniority { get; set; }
    }
}
