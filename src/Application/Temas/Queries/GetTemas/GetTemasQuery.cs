using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Temas.Queries.GetTemas
{
    public class GetTemasQuery : IRequest<List<TemaDto>>
    {
    }

    public class GetUsuariosQueryHandler : IRequestHandler<GetTemasQuery, List<TemaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsuariosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TemaDto>> Handle(GetTemasQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Temas
                .ProjectTo<TemaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
