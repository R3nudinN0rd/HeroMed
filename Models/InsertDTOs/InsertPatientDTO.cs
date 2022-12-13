using HeroMed_API.Entities.RelationsEntity;
using HeroMed_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeroMed_API.Models.InsertDTOs
{
    public class InsertPatientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhoneNumber { get; set; }
        public Guid SalonId { get; set; }

        public string IssueDetails { get; set; }
        public DateTime EnrolledDate { get; set; }
        public DateTime DischargeDate { get; set; }
    }
}
