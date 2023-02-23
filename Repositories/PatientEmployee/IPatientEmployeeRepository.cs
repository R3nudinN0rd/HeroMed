namespace HeroMed_API.Repositories.PatientEmployee
{
    public interface IPatientEmployeeRepository
    {
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeeRelationsAsync();
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetEmployeePatientsRelationsAsync(Guid employeeId);
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeesRelationsAsync(Guid patientId);
        Task<Entities.RelationsEntity.PatientEmployee> GetRelationAsync(Guid employeeId, Guid patientId);
        Task<Entities.RelationsEntity.PatientEmployee> AddRelationAsync(Entities.RelationsEntity.PatientEmployee employeePatientRelation);
        void UpdateRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation);
        void DeleteRelation(Guid employeeId, Guid patientId);
        bool RelationExists(Guid employeeId, Guid patientId);
    }
}
