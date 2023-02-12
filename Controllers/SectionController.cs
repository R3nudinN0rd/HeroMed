using AutoMapper;
using HeroMed_API.Entities;
using HeroMed_API.Models;
using HeroMed_API.Models.InsertDTOs;
using HeroMed_API.Models.UpdateDTOs;
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
        public ActionResult<IEnumerable<Models.SectionDTO>> GetAllSections()
        {
            var sectionsFromRepo = _sectionRepository.GetAllSectionsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(sectionsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<SectionDTO>>(sectionsFromRepo));
        }

        [HttpGet("/section/{sectionId}", Name = "GetSectionById")]
        public ActionResult<SectionDTO> GetSectionById(Guid sectionId)
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

            return Ok(_mapper.Map<SectionDTO>(sectionFromRepo));

        }
        [HttpPost]
        public ActionResult<Section> AddSection(InsertSectionDTO sectionDTO)
        {
            if (!_validator.ValidateSectionToInsert(sectionDTO))
            {
                return UnprocessableEntity();
            }

            var section = _mapper.Map<Section>(sectionDTO);
            section.Id = Guid.NewGuid();

            _sectionRepository.AddSection(section);

            return CreatedAtRoute("GetSectionById",
                                 new { sectionId = section.Id },
                                 sectionDTO);
        }

        [HttpPut("{sectionId}")]
        public ActionResult UpdateSection(Guid sectionId, UpdateSectionDTO sectionDTO)
        {
            if (!_validator.ValidateGuid(sectionId))
            {
                return BadRequest();
            }

            if (!_sectionRepository.SectionExists(sectionId))
            {
                return NotFound();
            }

            var sectionFromRepo = _sectionRepository.GetSectionByIdAsync(sectionId).GetAwaiter().GetResult();

            _mapper.Map(sectionDTO, sectionFromRepo);
            _sectionRepository.UpdateSection(sectionFromRepo);
            return NoContent();
        }
    }
}
