using HeroMed_API.Repositories.Statistics;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/statistics")]
    [EnableCors("AllowOrigins")]
    public class StatisticsController:ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository ?? throw new ArgumentNullException(nameof(statisticsRepository));
        }

        [HttpGet("enrolledMonth")]
        public async Task<ActionResult<Models.StatisticsDTO>> GetEnrolledPatientsByMonth(int month)
        {
            var statisticsResult = _statisticsRepository.GetEnrolledPatientsByMonth(month).GetAwaiter().GetResult();
            return Ok(statisticsResult);
        }

        [HttpGet("dischargeMonth")]
        public async Task<ActionResult<Models.StatisticsDTO>> GetDischargePatientsByMonth(int month)
        {
            var statisticsResult = _statisticsRepository.GetDischargedPatientsByMonth(month).GetAwaiter().GetResult();
            return Ok(statisticsResult);
        }

        [HttpGet("sectionId")]
        public async Task<ActionResult<Models.StatisticsDTO>> GetNumberOfPatientsBySection(Guid sectionId)
        {
            var statisticsResult = _statisticsRepository.GetNumberOfPatientsBySection(sectionId).GetAwaiter().GetResult();
            return Ok(statisticsResult);
        }

        [HttpGet("enrolledMonthSection")]
        public async Task<ActionResult<Models.StatisticsDTO>> GetNumberOfPatientsBySectionAndEnrolledMonth(Guid sectionId , int month)
        {
            var statisticsResiult = _statisticsRepository.GetNumberOfPatientsBySectionAndEnrolledMonth(sectionId, month).GetAwaiter().GetResult();
            return Ok(statisticsResiult);
        }

        [HttpGet("dischargeMonthSection")]
        public async Task<ActionResult<Models.StatisticsDTO>> GetNumberOfPatientsBySectionAndDischargeMonth(Guid sectionId, int month)
        {
            var statisticsResult = _statisticsRepository.GetNumberOfPatientsBySectionAndDischargeMonth(sectionId, month).GetAwaiter().GetResult();
            return Ok(statisticsResult);
        }
    }
}
