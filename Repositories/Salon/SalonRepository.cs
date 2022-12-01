using HeroMed_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.Repositories.Salon
{
    public class SalonRepository : ISalonRepository
    {
        private readonly HeroMedContext _context;
        public SalonRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.Salon>> GetAllSalonsAsync()
        {
            return await _context.Salons.ToListAsync();
        }

        public async Task<IEnumerable<Entities.Salon>> GetAvailableSalonsAsync()
        {
            return await _context.Salons.Where(s => s.Available == true)
                                        .ToListAsync();
        }

        public async Task<Entities.Salon> GetSalonByIdAsync(Guid Id)
        {
            return await _context.Salons.FirstOrDefaultAsync(s => s.Id == Id);
        }

        public async Task<IEnumerable<Entities.Salon>> GetSalonBySectionAsync(Guid sectionId)
        {
            return await _context.Salons.Where(s => s.SectionId == sectionId).ToListAsync();
        }

        public void UpdateSalon(Entities.Salon salon)
        {
            try
            {
                _context.Update(salon);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(salon));
            }
        }
    }
}
