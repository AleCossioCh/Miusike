using AutoMapper;
using ProyectoMiusike.Data.Entity;
using ProyectoMiusike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Data
{
    public class WindAppProfile : Profile
    {
        public WindAppProfile()
        {
            this.CreateMap<ArtistaEntity, Artista>()
                .ReverseMap();

            this.CreateMap<CacionEntity, Cacion>()
                .ReverseMap();
        }
    }
}
