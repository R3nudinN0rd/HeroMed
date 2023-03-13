using HeroMed_API.DatabaseContext;
using HeroMed_API.Models;
using HeroMed_API.Repositories.Salon;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace HeroMed_API.Repositories.Section
{
    public class SectionRepository : ISectionRepository
    {
        private readonly HeroMedContext _context;
        public SectionRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool SectionExists(Guid sectionId)
        {
            if(_context.Sections.FirstOrDefault(section => section.Id == sectionId) == null)
            {
                return false;
            }

            return true;
        }
        public async Task<IEnumerable<Entities.Section>> GetAllSectionsAsync()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task<Entities.Section> GetSectionByIdAsync(Guid id)
        {
            return await _context.Sections.FirstOrDefaultAsync<Entities.Section>(section => section.Id == id);
        }

        public async Task<Entities.Section> AddSectionAsync(Entities.Section section)
        {
            try
            {
                _context.Sections.Add(section);
                await _context.SaveChangesAsync();
                return section;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateSection(Entities.Section section)
        {
            try
            {
                _context.Sections.Update(section);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteSection(Guid id)
        {
            try
            {
                var section = _context.Sections.FirstOrDefault(s => s.Id == id);
                if (section == null) throw new ArgumentNullException(nameof(section));

                var salons = _context.Salons.ToList();

                foreach(var salon in salons)
                {
                    DeletePatientRelations(salon.Id);
                }

                _context.Sections.Remove(section);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        private void DeletePatientRelations(Guid salonId)
        {
            var patients = _context.Patients.Where(p => p.SalonId == salonId).ToList();

            foreach (var patient in patients)
            {
                var relations = _context.PatientEmployee.Where(r => r.PatientId == patient.Id).ToList();
                foreach (var relation in relations)
                {
                    _context.Remove(relation);
                }
            }

            _context.SaveChanges();
        }
    }
}
