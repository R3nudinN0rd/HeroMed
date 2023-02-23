namespace HeroMed_API.Repositories.Salon
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Entities.Salon>> GetAllSalonsAsync();
        Task<IEnumerable<Entities.Salon>> GetSalonBySectionAsync(Guid sectionId);
        Task<IEnumerable<Entities.Salon>> GetAvailableSalonsAsync();
        Task<Entities.Salon> GetSalonByIdAsync(Guid Id);
        Task<Entities.Salon> AddSalonAsync(Entities.Salon salon);
        void UpdateSalon(Entities.Salon salon);
        void DeleteSalon(Guid Id);
        bool SalonExists(Guid salonID);
    }
}
