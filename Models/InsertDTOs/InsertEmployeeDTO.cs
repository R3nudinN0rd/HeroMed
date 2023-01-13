using HeroMed_API.Entities.RelationsEntity;
using HeroMed_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeroMed_API.Models.InsertDTOs
{
    public class InsertEmployeeDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Nationality { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public char Gender { get; set; }
        public Decimal? Salary { get; set; }

        public string? SalaryCurrency { get; set; }

        public Guid JobId { get; set; }


        public Guid SectionId { get; set; }

        public int SeniorityYears { get; set; }

        public string? DocumentsPath { get; set; }

    }
}
