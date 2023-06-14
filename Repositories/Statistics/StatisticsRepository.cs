using HeroMed_API.DatabaseContext;
using HeroMed_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.Repositories.Statistics
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly HeroMedContext _context;

        public StatisticsRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<StatisticsDTO> GetDischargedPatientsByMonth(int month)
        {
            var patients = await _context.Patients.Where(p => p.DischargeDate.Month == month).ToListAsync();
            return new StatisticsDTO()
            {
                PatientsNumber = patients.Count
            };
        }

        public async Task<StatisticsDTO> GetEnrolledPatientsByMonth(int month)
        {
            var patients = await _context.Patients.Where(p => p.EnrolledDate.Month == month).ToListAsync();
            return new StatisticsDTO()
            {
                PatientsNumber = patients.Count
            };
        }

        public async Task<StatisticsDTO> GetNumberOfPatientsBySection(Guid sectionId)
        {
            List<Entities.Patient> patients = new List<Entities.Patient>();
            var salon = await _context.Salons.Where(s => s.SectionId == sectionId).ToListAsync();

            foreach (var s in salon)
            {
                var patientsSalon = await _context.Patients.Where(p => p.SalonId == s.Id).ToListAsync();

                foreach (var p in patientsSalon)
                {
                    patients.Add(p);
                }
            }

            return new StatisticsDTO()
            {
                PatientsNumber = patients.Count()
            };
        }

        public async Task<StatisticsDTO> GetNumberOfPatientsBySectionAndDischargeMonth(Guid sectionId, int month)
        {
            List<Entities.Patient> patients = new List<Entities.Patient>();
            var salon = await _context.Salons.Where(s => s.SectionId == sectionId).ToListAsync();

            foreach (var s in salon)
            {
                var patientsSalon = await _context.Patients.Where(p => p.SalonId == s.Id).ToListAsync();

                foreach (var p in patientsSalon)
                {
                    if(p.DischargeDate.Month == month)
                    {
                        patients.Add(p);
                    }
                }
            }

            return new StatisticsDTO()
            {
                PatientsNumber = patients.Count()
            };
        }

        public async Task<StatisticsDTO> GetNumberOfPatientsBySectionAndEnrolledMonth(Guid sectionId, int month)
        {
            List<Entities.Patient> patients = new List<Entities.Patient>();
            var salon = await _context.Salons.Where(s => s.SectionId == sectionId).ToListAsync();

            foreach (var s in salon)
            {
                var patientsSalon = await _context.Patients.Where(p => p.SalonId == s.Id).ToListAsync();

                foreach (var p in patientsSalon)
                {
                    if (p.EnrolledDate.Month == month)
                    {
                        patients.Add(p);
                    }
                }
            }

            return new StatisticsDTO()
            {
                PatientsNumber = patients.Count()
            };
        }
    }
}
