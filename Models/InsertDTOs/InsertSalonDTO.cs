namespace HeroMed_API.Models.InsertDTOs
{
    public class InsertSalonDTO
    {

        public int Floor { get; set; }
        public bool Available { get; set; }
        public int Beds { get; set; }
        public int SalonNumber { get; set; }
        public Guid SectionId { get; set; }
    }
}
