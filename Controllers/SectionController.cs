using AutoMapper;
using HeroMed_API.Repositories.Section;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionController:ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public SectionController(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository ?? throw new ArgumentNullException(nameof(sectionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet, HttpHead]
        public ActionResult<IEnumerable<Entities.Section>> GetSections()
        {
            var sectionsFromRepo = _sectionRepository.GetAllSectionsAsync();
            return Ok(sectionsFromRepo.GetAwaiter().GetResult());
        }

        [HttpGet("/{sectionId}")]
        public ActionResult GetSectionById(Guid sectionId)
        {
            var sectionFromRepo = _sectionRepository.GetSectionByIdAsync(sectionId);
            if (sectionFromRepo != null)
            {
                return NotFound();
            }

            return Ok(sectionFromRepo.GetAwaiter().GetResult());

        }

        [HttpPut]
        public ActionResult UpdateSection(Entities.Section section)
        {
            _sectionRepository.UpdateSection(section);
            return Ok();
        }
    }
}
