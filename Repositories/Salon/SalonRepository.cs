using HeroMed_API.DatabaseContext;
using Microsoft.Data.SqlClient;
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

        public bool SalonExists(Guid salonID)
        {
            if(_context.Salons.FirstOrDefault(salon => salon.Id == salonID)==null)
            {
                return false;
            }

            return true;
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

        public async Task<Models.SingleValueDTOs.IntegerDTO> GetNumberOfPatients(Guid Id)
        {
            Models.SingleValueDTOs.IntegerDTO integerDTO = new Models.SingleValueDTOs.IntegerDTO();
            integerDTO.Number = (await _context.Patients.Where(p => p.SalonId == Id).ToListAsync()).Count();
            return integerDTO; 
        }

        public async Task<IEnumerable<Entities.Salon>> GetSalonBySectionAsync(Guid sectionId)
        {
            return await _context.Salons.Where(s => s.SectionId == sectionId).ToListAsync();
        }

        public async Task<Entities.Salon> AddSalonAsync(Entities.Salon salon)
        {
            try
            {
                _context.Salons.Add(salon);
                await _context.SaveChangesAsync();
                return salon;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateSalon(Entities.Salon salon)
        {
            try
            {
                _context.Update(salon);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteSalon(Guid id)
        {
            try
            {
                var salon = _context.Salons.FirstOrDefault(s => s.Id == id);
                if (salon == null) throw new ArgumentNullException(nameof(salon));
                
                DeletePatientRelations(id);

                _context.Salons.Remove(salon);
                _context.SaveChanges();
            }
            catch (SqlException ex)
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
