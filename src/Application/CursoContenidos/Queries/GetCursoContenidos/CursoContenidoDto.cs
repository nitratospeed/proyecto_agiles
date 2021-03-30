using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CursoContenidos.Queries.GetCursoContenidos
{
    public class CursoContenidoDto : IMapFrom<CursoContenido>
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public List<CursoContenidoDetalle> CursoContenidoDetalles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CursoContenido, CursoContenidoDto>();
        }
    }
}
