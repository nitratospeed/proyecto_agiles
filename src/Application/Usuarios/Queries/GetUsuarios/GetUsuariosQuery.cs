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

namespace Application.Usuarios.Queries.GetUsuarios
{
    public class GetUsuariosQuery : IRequest<PaginatedList<UsuarioDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, PaginatedList<UsuarioDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsuariosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UsuarioDto>> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Usuarios
                .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
