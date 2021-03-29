using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Sumarizados.Queries.GetSumarizados
{
    public class GetSumarizadosQuery : IRequest<SumarizadoDto>
    {

    }

    public class GetSumarizadosQueryHandler : IRequestHandler<GetSumarizadosQuery, SumarizadoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSumarizadosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SumarizadoDto> Handle(GetSumarizadosQuery request, CancellationToken cancellationToken)
        {
            var docentesCount = await _context.Docentes.CountAsync();
            var cursosCount = await _context.Cursos.CountAsync();
            var cursosCertificadosCount = await _context.Certificados.CountAsync();

            var result = new SumarizadoDto()
            {
                Cursos = cursosCount,
                Docentes = docentesCount,
                CursosCertificados = cursosCertificadosCount
            };

            return result;
        }
    }
}
