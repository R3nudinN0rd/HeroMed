using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Repositories.PatientEmployee
{
    public interface IPatientEmployeeRepository
    {
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeeRelationsAsync();
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetEmployeePatientsRelationsAsync(Guid employeeId);
        Task<IEnumerable<Entities.RelationsEntity.PatientEmployee>> GetPatientEmployeesRelationsAsync(Guid patientId);
        Task<Entities.RelationsEntity.PatientEmployee> GetRelationAsync(Guid employeeId, Guid patientId);
        Task<Entities.RelationsEntity.PatientEmployee> AddRelationAsync(Entities.RelationsEntity.PatientEmployee employeePatientRelation);
        IEnumerable<Entities.RelationsEntity.PatientEmployee> GetEmployeeExternalValuesAsync(Guid employeeId);
        IEnumerable<Entities.RelationsEntity.PatientEmployee> GetPatientExternalValuesAsync(Guid patientId);
        void UpdateRelation(Entities.RelationsEntity.PatientEmployee employeePatientRelation, Entities.RelationsEntity.PatientEmployee relationDTO);
        void DeleteRelation(Guid employeeId, Guid patientId);
        void DeleteRelationByPatientId(Guid patientId);
        void DeleteRelationByEmployeeId(Guid employeeId);
        bool RelationExists(Guid employeeId, Guid patientId);
    }
}
