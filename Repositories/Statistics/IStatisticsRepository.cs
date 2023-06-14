namespace HeroMed_API.Repositories.Statistics
{
    public interface IStatisticsRepository
    {
        Task<Models.StatisticsDTO> GetEnrolledPatientsByMonth(int month);
        Task<Models.StatisticsDTO> GetDischargedPatientsByMonth(int month);
        Task<Models.StatisticsDTO> GetNumberOfPatientsBySection(Guid sectionId);
        Task<Models.StatisticsDTO> GetNumberOfPatientsBySectionAndEnrolledMonth(Guid sectionId, int month);
        Task<Models.StatisticsDTO> GetNumberOfPatientsBySectionAndDischargeMonth(Guid sectionId, int month);
    }
}
