using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cursos.Commands.CreateCursoUsuario
{
    public class CreateCursoUsuarioCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
    }

    public class CreateCursoUsuarioCommandHandler : IRequestHandler<CreateCursoUsuarioCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public CreateCursoUsuarioCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateCursoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = false;

            var entity = new CursoUsuario
            {
                CursoId = request.CursoId,
                UsuarioId = request.UsuarioId
            };

            _context.CursoUsuarios.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            result = true;

            return result;
        }
    }
}
