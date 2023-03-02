namespace HeroMed_API.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email{ get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Admin { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
