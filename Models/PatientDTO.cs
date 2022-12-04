namespace HeroMed_API.Models
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumebr { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public Guid SalonId { get; set; }
        public string IssueDetails { get; set; }
        public DateOnly EnrolledDate { get; set; }
        public DateOnly DischargeDate { get; set; }
    }
}
