namespace HeroMed_API.Repositories.PatientEmployee
{
    public interface IPatientEmployeeRepository
    {
        Task<IEnumerable<Entities.Patient>> GetEmployeePatientsAsync(Guid employeeId);
        Task<IEnumerable<Entities.Employee>> GetPatientEmployeeAsync(Guid patientId);
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeeRelationsAsync(Guid employeeId);
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetEmployeePatientsRelationsAsync(Guid employeeId);
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeesRelationsAsync(Guid patientId);
        Task<Entities.RelationsEntity.PatientEmployee> GetRelation(Guid employeeId, Guid patientId);
        void AddRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation);
        void UpdateRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation);
        void DeleteRelation(Guid employeeId, Guid patientId);
    }
}
