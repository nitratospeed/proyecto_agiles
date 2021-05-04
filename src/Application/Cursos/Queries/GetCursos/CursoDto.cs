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
        public int CategoriaId { get; set; }
        public int TemaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Docente { get; set; }
        public string TipoAsistencia { get; set; }
        public decimal Precio { get; set; }
        public bool BrindaCertificado { get; set; } = true;
        public decimal CostoCertificado { get; set; }
        public decimal Calificacion { get; set; }
        public string UrlImagen { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Curso, CursoDto>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.Categoria.Id))
                .ForMember(dest => dest.Docente, opt => opt.MapFrom(src => src.Docente.Nombre))
                .ForMember(dest => dest.CostoCertificado, opt => opt.MapFrom(src => src.Certificado.Costo))
                .ForMember(dest => dest.CostoCertificado, opt => opt.MapFrom(src => src.Certificado.Costo));
        }
    }
}
