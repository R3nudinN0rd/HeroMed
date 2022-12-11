using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Repositories.Section;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("api/sections")]
    [EnableCors("AllowOrigins")]
    public class SectionController:ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validator;

        public SectionController(ISectionRepository sectionRepository, IMapper mapper, ControllersInputsValidators validator)
        {
            _sectionRepository = sectionRepository ?? throw new ArgumentNullException(nameof(sectionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet, HttpHead]
        public ActionResult<IEnumerable<Models.SectionDTO>> GetSections()
        {
            var sectionsFromRepo = _sectionRepository.GetAllSectionsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(sectionsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Section>>(sectionsFromRepo));
        }

        [HttpGet("/section/{sectionId}")]
        public ActionResult<Section> GetSectionById(Guid sectionId)
        {
            if (!_validator.ValidateGuid(sectionId))
            {
                return BadRequest();
            }

            var sectionFromRepo = _sectionRepository.GetSectionByIdAsync(sectionId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(sectionFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Section>(sectionFromRepo));

        }

        [HttpPut]
        public ActionResult UpdateSection(Entities.Section section)
        {
            _sectionRepository.UpdateSection(section);
            return Ok();
        }
    }
}
