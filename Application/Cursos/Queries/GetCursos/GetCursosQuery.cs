using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cursos.Queries.GetCursos
{
    public class GetCursoQuery : IRequest<PaginatedList<CursoDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Nombre { get; set; } = "";
        public int CategoriaId { get; set; } = 0;
    }

    public class GetCursoQueryHandler : IRequestHandler<GetCursoQuery, PaginatedList<CursoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCursoQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CursoDto>> Handle(GetCursoQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Cursos
                .Where(x=>x.Nombre.ToLower().Contains(request.Nombre.ToLower()) || request.Nombre == "")
                .Where(x => x.CategoriaId == request.CategoriaId || request.CategoriaId == 0)
                .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
