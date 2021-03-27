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

namespace Application.Cursos.Queries.GetCursos
{
    public class GetCursoByIdQuery : IRequest<CursoDto>
    {
        public int Id { get; set; }
    }

    public class GetCursoByIdQueryHandler : IRequestHandler<GetCursoByIdQuery, CursoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCursoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CursoDto> Handle(GetCursoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Cursos
                .Where(x => x.Id == request.Id)
                .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
