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

namespace Application.Usuarios.Queries.GetUsuarios
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioDto>
    {
        public int Id { get; set; }
    }

    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Usuarios
                .Where(x => x.Id == request.Id)
                .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
