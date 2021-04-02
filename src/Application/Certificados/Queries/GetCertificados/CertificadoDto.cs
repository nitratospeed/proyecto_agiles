using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Certificados.Queries.GetCertificados
{
    public class CertificadoDto : IMapFrom<Certificado>
    {
        public int Id { get; set; }
        public string Condicion { get; set; }
        public decimal Costo { get; set; }
        public int CursoId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Certificado, CertificadoDto>();
        }
    }
}
