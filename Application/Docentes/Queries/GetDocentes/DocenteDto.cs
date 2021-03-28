using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Docentes.Queries.GetDocentes
{
    public class DocenteDto : IMapFrom<Docente>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Docente, DocenteDto>();
        }
    }
}
