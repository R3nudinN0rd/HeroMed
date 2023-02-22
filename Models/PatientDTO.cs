namespace HeroMed_API.Models
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumebr { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public Guid SalonId { get; set; }
        public string IssueDetails { get; set; }
        public DateTimeOffset EnrolledDate { get; set; }
        public DateTimeOffset DischargeDate { get; set; }
    }
}
