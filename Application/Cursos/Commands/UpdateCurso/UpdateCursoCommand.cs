using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cursos.Commands.UpdateCurso
{
    public class UpdateCursoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class UpdateCursoCommandHandler : IRequestHandler<UpdateCursoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCursoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateCursoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cursos.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Cursos), request.Id);
            }

            entity.Id = request.Id;
            entity.Nombre = request.Nombre;

            await _context.SaveChangesAsync(cancellationToken);

            var result = 1;

            return result;
        }
    }
}
