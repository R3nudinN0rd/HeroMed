namespace HeroMed_API.Repositories.Patient
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Entities.Patient>> GetAllPatientsAsync();
        Task<Entities.Patient> GetPatientByIdAsync(Guid id);
        Task<IEnumerable<Entities.Patient>> GetPatientBySalonAsync(Guid salonId);
        Task<Entities.Patient> GetPatientByPatientEmailAsync(string email);
        Task<Entities.Patient> AddPatientAsync(Entities.Patient patient);
        void DeletePatient(Guid id);
        void UpdatePatient(Entities.Patient patient);
        bool PatientExists(Guid patientId);
    }
}
