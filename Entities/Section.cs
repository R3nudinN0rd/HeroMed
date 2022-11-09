using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroMed_API.Entities
{
    [Table("Sections")]
    public class Section
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is a required field!")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Maximum number of emloyees is a required field!"), Range(1, int.MaxValue)]
        public int MaximumEmployeesNo { get; set; }
        public ICollection<Employee> Sections { get; set; } = new List<Employee>();
    }
}
