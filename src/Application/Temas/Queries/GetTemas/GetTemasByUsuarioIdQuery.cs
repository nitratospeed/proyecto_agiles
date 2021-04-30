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

namespace Application.Temas.Queries.GetTemas
{
    public class GetTemasByUsuarioIdQuery : IRequest<List<TemaDto>>
    {
        public int UsuarioId { get; set; } = 0;
    }

    public class GetTemasByUsuarioIdQueryHandler : IRequestHandler<GetTemasByUsuarioIdQuery, List<TemaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTemasByUsuarioIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TemaDto>> Handle(GetTemasByUsuarioIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.UsuarioTemas
                .Include(x => x.Usuario)
                .Where(x => x.UsuarioId == request.UsuarioId)
                .Select(x => x.Tema)
                .ProjectTo<TemaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
