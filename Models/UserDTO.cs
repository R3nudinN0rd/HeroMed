namespace HeroMed_API.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username{ get; set; }
        public DateOnly CreatedDate { get; set; }
        public bool Admin { get; set; }
        public Guid EmployeeAccount { get; set; }
    }
}
