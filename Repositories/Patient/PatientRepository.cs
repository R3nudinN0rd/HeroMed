using HeroMed_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.Repositories.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HeroMedContext _context;
        public PatientRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool PatientExists(Guid patientID)
        {
            if(_context.Patients.FirstOrDefault(patient => patient.Id == patientID) == null)
            {
                return false;
            }

            return true;
        }

        public void AddPatient(Entities.Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(patient));
            }
        }

        public void DeletePatient(Guid id)
        {
            try
            {
                var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
                if (patient == null) throw new ArgumentNullException(nameof(patient));
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task<IEnumerable<Entities.Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Entities.Patient> GetPatientByIdAsync(Guid id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Entities.Patient> GetPatientByPatientEmailAsync(string email)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<Entities.Patient>> GetPatientBySalonAsync(Guid salonId)
        {
            return await _context.Patients.Where(p => p.SalonId == salonId).ToListAsync();
        }

        public void UpdatePatient(Entities.Patient patient)
        {
            try
            {
                _context.Patients.Update(patient);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(patient));
            }
        }
    }
}
