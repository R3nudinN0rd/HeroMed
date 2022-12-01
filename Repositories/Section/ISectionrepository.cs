namespace HeroMed_API.Repositories.Section
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Entities.Section>> GetAllSectionsAsync();
        Task<Entities.Section> GetSectionByIdAsync(Guid id);
        void UpdateSection(Entities.Section section);
    }
}
