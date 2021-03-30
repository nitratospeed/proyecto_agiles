using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Docentes.Queries.GetDocentes
{
    public class GetDocentesQuery : IRequest<PaginatedList<DocenteDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetDocentesQueryHandler : IRequestHandler<GetDocentesQuery, PaginatedList<DocenteDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDocentesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DocenteDto>> Handle(GetDocentesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Docentes
                .ProjectTo<DocenteDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
