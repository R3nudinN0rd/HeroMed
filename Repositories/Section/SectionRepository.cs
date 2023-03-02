using HeroMed_API.DatabaseContext;
using HeroMed_API.Models;
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
                _context.Sections.Remove(section);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
