using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUsuarioCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = new Usuario
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Correo = request.Correo,
                Contrasena = request.Contrasena
            };

            _context.Usuarios.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
