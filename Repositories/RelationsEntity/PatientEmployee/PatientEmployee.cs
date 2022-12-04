using HeroMed_API.DatabaseContext;

namespace HeroMed_API.Repositories.RelationsEntity.PatientEmployee
{
    public class PatientEmployee : IPatientEmployee
    {
        private readonly HeroMedContext _context;
        public PatientEmployee(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddRelation(PatientEmployee relation)
        {

        }

        public Task<IEnumerable<PatientEmployee>> GetAllRelationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Employee> GetEmployeeByRelationIds(Guid patientId, Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Employee>> GetEmployeesByPatientId(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Patient> GetPatientByRelationIds(Guid patientId, Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Patient>> GetPatientsByEmployeeId(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<PatientEmployee> GetRelationByIds(Guid patientId, Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientEmployee>> GetRelationsByEmployeeIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientEmployee>> GetRelationsByPatientIdAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }
    }
}
