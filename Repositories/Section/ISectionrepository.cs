using HeroMed_API.Models;

namespace HeroMed_API.Repositories.Section
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Entities.Section>> GetAllSectionsAsync();
        Task<Entities.Section> GetSectionByIdAsync(Guid id);
        Task<Entities.Section> AddSectionAsync(Entities.Section section);
        void UpdateSection(Entities.Section section);
        bool SectionExists(Guid sectionId);
    }
}
