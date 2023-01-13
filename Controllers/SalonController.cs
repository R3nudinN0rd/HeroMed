﻿using AutoMapper;
using HeroMed_API.DatabaseContext;
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
        public ActionResult<IEnumerable<Models.SalonDTO>> GetSalons()
        {
            var salonsFromRepo = _salonRepository.GetAllSalonsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(salonsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.SalonDTO>>(salonsFromRepo));
        }

        [HttpGet("/salon/{sectionId}")]
        public ActionResult<IEnumerable<Models.SalonDTO>> GetSalonsBySectionId(Guid sectionId)
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
        public ActionResult<IEnumerable<Models.SalonDTO>> GetAvailableSalons()
        {
            var salonsFromRepo = _salonRepository.GetAvailableSalonsAsync().GetAwaiter().GetResult();
            if (!_validator.ValidateResult(salonsFromRepo))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<Models.SalonDTO>>(salonsFromRepo));
        }


        [HttpGet("id/{id}")]
        public ActionResult<Models.SalonDTO> GetSalonById(Guid id)
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

        [HttpPut("{salonId}")]
        public ActionResult UpdateSalon(Guid salonId, UpdateSalonDTO salonDTO)
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
    }
}