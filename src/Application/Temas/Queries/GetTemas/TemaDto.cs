using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Temas.Queries.GetTemas
{
    public class TemaDto : IMapFrom<Tema>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tema, TemaDto>();
        }
    }
}
