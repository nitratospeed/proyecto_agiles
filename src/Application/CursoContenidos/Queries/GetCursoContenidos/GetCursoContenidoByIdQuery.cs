using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CursoContenidos.Queries.GetCursoContenidos
{
    public class GetCursoContenidoByIdQuery : IRequest<List<CursoContenidoDto>>
    {
        public int Id { get; set; }
    }

    public class GetCursoContenidoByIdQueryHandler : IRequestHandler<GetCursoContenidoByIdQuery, List<CursoContenidoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCursoContenidoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CursoContenidoDto>> Handle(GetCursoContenidoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.CursoContenidos
                .Where(x => x.CursoId == request.Id)
                .ProjectTo<CursoContenidoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
