using HeroMed_API.DatabaseContext;
using HeroMed_API.Models;
using Microsoft.EntityFrameworkCore;

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

        public void AddSection(Entities.Section section)
        {
            try
            {
                _context.Sections.Add(section);
                _context.SaveChanges();
            }
            catch(Exception ex)
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
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(section));
            }
        }
    }
}
