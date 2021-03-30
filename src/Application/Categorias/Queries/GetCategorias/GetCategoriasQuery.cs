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

namespace Application.Categorias.Queries.GetCategorias
{
    public class GetCategoriasQuery : IRequest<PaginatedList<CategoriaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, PaginatedList<CategoriaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriasQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CategoriaDto>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categorias
                .ProjectTo<CategoriaDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
