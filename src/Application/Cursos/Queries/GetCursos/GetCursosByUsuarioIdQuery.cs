using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cursos.Queries.GetCursos
{
    public class GetCursosByUsuarioIdQuery : IRequest<List<CursoDto>>
    {
        public int UsuarioId { get; set; } = 0;
        public bool Recomendado { get; set; } = false;
    }

    public class GetCursosByUsuarioIdQueryHandler : IRequestHandler<GetCursosByUsuarioIdQuery, List<CursoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCursosByUsuarioIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CursoDto>> Handle(GetCursosByUsuarioIdQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CursoDto>();

            if (request.Recomendado)
            {
                var sd = await _context.UsuarioTemas.Include(x => x.Tema).Where(x => x.UsuarioId == request.UsuarioId)
                    .Select(x => x.Tema).ToListAsync();

                foreach (var item in sd)
                {
                    var cursotema = await _context.Cursos
                    .Where(x=>x.TemaId == item.Id)
                    .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                    result.AddRange(cursotema);
                }
            }
            else
            {
                result = await _context.CursoUsuarios
                    .Include(x => x.Curso)
                    .Where(x => x.UsuarioId == request.UsuarioId)
                    .Select(x => x.Curso)
                    .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }


            return result;
        }
    }
}
