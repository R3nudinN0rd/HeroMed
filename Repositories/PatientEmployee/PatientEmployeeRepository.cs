using HeroMed_API.DatabaseContext;
using Microsoft.Data.SqlClient;
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

        public bool RelationExists(Guid employeeId, Guid patientId)
        {
            if(_context.PatientEmployee.FirstOrDefault(relation => relation.EmployeeId == employeeId && relation.PatientId == patientId) == null)
            {
                return false;
            }

            return true;
        }
        public async Task<Entities.RelationsEntity.PatientEmployee> AddRelationAsync(Entities.RelationsEntity.PatientEmployee employeePatientRelation)
        {
            try
            {
                _context.PatientEmployee.Add(employeePatientRelation);
                await _context.SaveChangesAsync();
                return employeePatientRelation;
            }
            catch (SqlException ex)
            {
                throw ex;
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
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetEmployeePatientsRelationsAsync(Guid employeeId)
        {
            return await _context.PatientEmployee.Where(r => r.EmployeeId == employeeId).ToListAsync();
        }


        public async Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeeRelationsAsync()
        {
            return await _context.PatientEmployee.ToListAsync();
        }

        public async Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeesRelationsAsync(Guid patientId)
        {
            return await _context.PatientEmployee.Where(r => r.PatientId == patientId).ToListAsync();
        }

        public async Task<Entities.RelationsEntity.PatientEmployee> GetRelationAsync(Guid employeeId, Guid patientId)
        {
            return await _context.PatientEmployee.FirstOrDefaultAsync(r => r.EmployeeId == employeeId && r.PatientId == patientId);
        }

        public void UpdateRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation)
        {
            try
            {
                _context.PatientEmployee.Remove(employeePatientRelation);
                _context.SaveChanges();
                _context.PatientEmployee.Add(employeePatientRelation);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
