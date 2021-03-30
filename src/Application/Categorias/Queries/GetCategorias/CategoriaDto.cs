using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Categorias.Queries.GetCategorias
{
    public class CategoriaDto : IMapFrom<Categoria>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Categoria, CategoriaDto>();
        }
    }
}
