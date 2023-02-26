using AutoMapper;
using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using HeroMed_API.Models;
using HeroMed_API.Models.UpdateDTOs;
using HeroMed_API.Repositories.Salon;
using HeroMed_API.Validators;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeroMed_API.Controllers
{
    [ApiController]
    [Route("/api/salon")]
    [EnableCors("AllowOrigins")]
    public class SalonController:ControllerBase
    {
        private readonly ISalonRepository _salonRepository;
        private readonly IMapper _mapper;
        private readonly ControllersInputsValidators _validator;

        public SalonController(ISalonRepository salonRepository, IMapper mapper, ControllersInputsValidators validator)
        {
            _salonRepository = salonRepository ?? throw new ArgumentNullException(nameof(salonRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<Models.SalonDTO>>> GetSalons()
        {
            var salonsFromRepo = _salonRepository.GetAllSalonsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(salonsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.SalonDTO>>(salonsFromRepo));
        }

        [HttpGet("/salon/{sectionId}")]
        public async Task<ActionResult<IEnumerable<Models.SalonDTO>>> GetSalonsBySectionId(Guid sectionId)
        {
            if (!_validator.ValidateGuid(sectionId))
            {
                return BadRequest();
            }

            var salonsFromRepo = _salonRepository.GetSalonBySectionAsync(sectionId).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(salonsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.SalonDTO>>(salonsFromRepo));
        }

        [HttpGet("/salon/available")]
        public async Task<ActionResult<IEnumerable<Models.SalonDTO>>> GetAvailableSalons()
        {
            var salonsFromRepo = _salonRepository.GetAvailableSalonsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(salonsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.SalonDTO>>(salonsFromRepo));
        }


        [HttpGet("id/{id}",Name = "GetSalonById")]
        public async Task<ActionResult<Models.SalonDTO>> GetSalonById(Guid id)
        {
            if (!_validator.ValidateGuid(id))
            {
                return BadRequest();
            }

            var salonFromRepo = _salonRepository.GetSalonByIdAsync(id).GetAwaiter().GetResult();

            if (!_validator.ValidateResult(salonFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Models.SalonDTO>(salonFromRepo));
        }

        [HttpGet("patients/{id}")]
        public async Task<ActionResult<int>> GetPatientsFromSalon(Guid id)
        {
            if (!_validator.ValidateGuid(id))
            {
                return BadRequest();
            }

            var numberOfPatients = _salonRepository.GetNumberOfPatients(id).GetAwaiter().GetResult();

            return Ok(numberOfPatients);
        }

        [HttpPost]
        public async Task<ActionResult> AddSalon(Models.InsertDTOs.InsertSalonDTO salonDTO)
        {
            if (!_validator.ValidateSalonToInsert(salonDTO))
            {
                return UnprocessableEntity();
            }

            var salon = _mapper.Map<Salon>(salonDTO);
            salon.Id = Guid.NewGuid();

            await _salonRepository.AddSalonAsync(salon);

            return CreatedAtRoute("GetSalonById",
                                  new { id = salon.Id },
                                  salonDTO);
        }

        [HttpPut("{salonId}")]
        public async Task<ActionResult> UpdateSalon(Guid salonId, UpdateSalonDTO salonDTO)
        {
            if (!_validator.ValidateGuid(salonId))
            {
                return BadRequest();
            }

            if (!_salonRepository.SalonExists(salonId))
            {
                return NotFound();
            }

            var salonFromRepo = _salonRepository.GetSalonByIdAsync(salonId).GetAwaiter().GetResult();

            _mapper.Map(salonDTO, salonFromRepo);
            _salonRepository.UpdateSalon(salonFromRepo);
            return NoContent();
        }
        [HttpDelete("{salonId}")]
        public async Task<ActionResult> DeleteSalon(Guid salonId)
        {
            if (!_validator.ValidateGuid(salonId))
            {
                return BadRequest();
            }

            _salonRepository.DeleteSalon(salonId);
            return NoContent();
        }
    }
}
