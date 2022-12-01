using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroMed_API.Entities
{
    [Table("Salon")]
    public class Salon
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Floor is a required field!")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Beds is a required field!")]
        public int Beds { get; set; }

        [Required(ErrorMessage = "Available is a required field!")]
        public bool Available { get; set; }

        [Required(ErrorMessage = "Section is a required field!"), ForeignKey("SectionId")]
        public Section Section { get; set; }
        public Guid SectionId { get; set; }

        public ICollection<Patient> Patient { get; set; } = new List<Patient>();
    }
}
