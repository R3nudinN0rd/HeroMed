using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using HeroMed_API.Models;
using Microsoft.AspNetCore.Mvc;
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

        public void UpdateRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation, Entities.RelationsEntity.PatientEmployee relationDTO)
        {
            try
            {
                _context.PatientEmployee.Remove(employeePatientRelation);
                _context.PatientEmployee.Add(relationDTO);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Entities.RelationsEntity.PatientEmployee> GetPatientExternalValuesAsync(Guid employeeId)
        {
            List<Entities.RelationsEntity.PatientEmployee> relations = new List<Entities.RelationsEntity.PatientEmployee>();
            var currentIds = _context.PatientEmployee.Where(r => r.EmployeeId == employeeId).ToList();
            var patients = _context.Patients.ToList();

            foreach (var patId in patients)
            {
                bool found = false;
                foreach (var id in currentIds)
                {
                    if (patId.Id == id.PatientId)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    relations.Add(
                        new Entities.RelationsEntity.PatientEmployee
                        {
                            PatientId = patId.Id,
                            EmployeeId = employeeId
                        });
                }
            }

            return relations;
        }

        public IEnumerable<Entities.RelationsEntity.PatientEmployee> GetEmployeeExternalValuesAsync(Guid patientId)
        {
            List<Entities.RelationsEntity.PatientEmployee> relations = new List<Entities.RelationsEntity.PatientEmployee>();
            var currentIds = _context.PatientEmployee.Where(r => r.PatientId == patientId).ToList();          
            var employees = _context.Employees.ToList();
            
            foreach(var emplId in employees)
            {
                bool found = false;
                foreach(var id in currentIds)
                {
                    if (emplId.Id == id.EmployeeId)
                    {
                        found= true;
                        break;
                    }
                }

                if(found == false)
                {
                    relations.Add(
                        new Entities.RelationsEntity.PatientEmployee
                        {
                            PatientId = patientId,
                            EmployeeId = emplId.Id
                        });
                }
            }
            return relations;
        }

        public void DeleteRelationByPatientId(Guid patientId)
        {
            try
            {
                var relations = _context.PatientEmployee.Where(r => r.PatientId == patientId);
                foreach (var relation in relations)
                {
                    _context.PatientEmployee.Remove(relation);  
                }
                _context.SaveChanges();
            }

            catch (SqlException ex)
            {
                throw ex;
            }
        }
  

        public void DeleteRelationByEmployeeId(Guid employeeId)
        {
        try
        {
            var relations = _context.PatientEmployee.Where(r => r.PatientId == employeeId);
            foreach (var relation in relations)
            {
                _context.PatientEmployee.Remove(relation);
            }

            _context.SaveChanges();
            
        }

        catch (SqlException ex)
        {
            throw ex;
        }
    }
}
    }
