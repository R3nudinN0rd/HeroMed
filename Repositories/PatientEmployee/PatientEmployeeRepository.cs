using HeroMed_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.Repositories.PatientEmployee
{
    public class PatientEmployeeRepository : IPatientEmployeeRepository
    {
        private readonly HeroMedContext _context;
        public PatientEmployeeRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation)
        {
            try
            {
                _context.PatientEmployee.Add(employeePatientRelation);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(employeePatientRelation));
            }
        }

        public void DeleteRelation(Guid employeeId, Guid patientId)
        {
            try
            {
                var relation = _context.PatientEmployee.FirstOrDefault(r => (r.PatientId == patientId && r.EmployeeId == employeeId));
                if(relation == null)
                {
                    throw new ArgumentNullException(nameof(relation));
                }

                _context.PatientEmployee.Remove(relation);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(employeeId), nameof(patientId));
            }
        }

        public async Task<IEnumerable<Entities.Patient>> GetEmployeePatientsAsync(Guid employeeId)
        {
            IEnumerable<Entities.RelationsEntity.PatientEmployee> patientsIds =await _context.PatientEmployee.Where(r => r.EmployeeId == employeeId).ToListAsync();

            if(patientsIds == null)
            {
                throw new ArgumentNullException(nameof(patientsIds));
            }

            List<Entities.Patient> patients = new List<Entities.Patient>();

            patientsIds.AsParallel().ForAll(i =>
            {
                patients.Add(_context.Patients.FirstOrDefault(p => p.Id == i.PatientId));
            });

            return patients;

        }

        public async Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetEmployeePatientsRelationsAsync(Guid employeeId)
        {
            return await _context.PatientEmployee.Where(r => r.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Employee>> GetPatientEmployeeAsync(Guid patientId)
        {
            IEnumerable<Entities.RelationsEntity.PatientEmployee> employeeIds = await _context.PatientEmployee.Where(r => r.PatientId == patientId).ToListAsync();
            if(employeeIds == null)
            {
                throw new ArgumentNullException(nameof(employeeIds));
            }

            List<Entities.Employee> employees = new List<Entities.Employee>();

            employeeIds.AsParallel().ForAll(i =>
            {
                employees.Add(_context.Employees.FirstOrDefault(e => e.Id == i.EmployeeId));
            });
            return employees;
        }

        public async Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeeRelationsAsync(Guid employeeId)
        {
            return await _context.PatientEmployee.Where(r => r.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeesRelationsAsync(Guid patientId)
        {
            return await _context.PatientEmployee.Where(r => r.PatientId == patientId).ToListAsync();
        }

        public async Task<Entities.RelationsEntity.PatientEmployee> GetRelation(Guid employeeId, Guid patientId)
        {
            return await _context.PatientEmployee.FirstOrDefaultAsync(r => r.EmployeeId == employeeId && r.PatientId == patientId);
        }

        public void UpdateRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation)
        {
            try
            {
                _context.PatientEmployee.Update(employeePatientRelation);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(employeePatientRelation));
            }
        }
    }
}
