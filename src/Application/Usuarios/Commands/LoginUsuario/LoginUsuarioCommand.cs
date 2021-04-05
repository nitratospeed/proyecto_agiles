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
    public class LoginUsuarioCommand : IRequest<UsuarioDto>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, UsuarioDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LoginUsuarioCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Usuarios
                .Where(x => x.Correo == request.Correo && x.Contrasena == request.Contrasena)
                .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
