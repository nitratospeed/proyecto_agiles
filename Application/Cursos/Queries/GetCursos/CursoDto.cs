using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cursos.Queries.GetCursos
{
    public class CursoDto : IMapFrom<Curso>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Curso, CursoDto>();
        }
    }
}
