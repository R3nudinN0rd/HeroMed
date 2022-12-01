namespace HeroMed_API.Repositories.Salon
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Entities.Salon>> GetAllSalonsAsync();
        Task<IEnumerable<Entities.Salon>> GetSalonBySectionAsync(Guid sectionId);
        Task<IEnumerable<Entities.Salon>> GetAvailableSalonsAsync();
        Task<Entities.Salon> GetSalonByIdAsync(Guid Id);
        void UpdateSalon(Entities.Salon salon);
    }
}
