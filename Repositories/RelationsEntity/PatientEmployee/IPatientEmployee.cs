namespace HeroMed_API.Repositories.RelationsEntity.PatientEmployee
{
    public interface IPatientEmployee
    {
        Task<IEnumerable<PatientEmployee>> GetAllRelationsAsync();
        Task<IEnumerable<PatientEmployee>> GetRelationsByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<PatientEmployee>> GetRelationsByPatientIdAsync(Guid patientId);
        Task<PatientEmployee> GetRelationByIds(Guid patientId, Guid employeeID);
        Task<IEnumerable<Entities.Patient>> GetPatientsByEmployeeId(Guid employeeId);
        Task<IEnumerable<Entities.Employee>> GetEmployeesByPatientId(Guid patientId);
        Task<Entities.Employee> GetEmployeeByRelationIds(Guid patientId, Guid employeeID);
        Task<Entities.Patient> GetPatientByRelationIds(Guid patientId, Guid employeeID);
        void AddRelation(PatientEmployee relation);
    }
}
