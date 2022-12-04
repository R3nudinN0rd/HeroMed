﻿using AutoMapper;

namespace HeroMed_API.Profiles.Salon
{
    public class SalonProfile:Profile
    {
        public SalonProfile()
        {
            CreateMap<Entities.Salon, Models.SalonDTO>();
        }
    }
}
