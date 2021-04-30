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
        public List<Tema> Temas { get; set; }

        public class Tema 
        {
            public int TemaId { get; set; }
        }
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

            var listUsuarioTemas = new List<UsuarioTema>();

            foreach (var item in request.Temas)
            {
                var usuarioTema = new UsuarioTema
                {
                    UsuarioId = result,
                    TemaId = item.TemaId
                };
                listUsuarioTemas.Add(usuarioTema);                
            }

            await _context.UsuarioTemas.AddRangeAsync(listUsuarioTemas);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
