namespace HeroMed_API.Models
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly Birthdate { get; set; }
        public DateOnly EmployementDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public int SeniorityYears { get; set; }
    }
}
