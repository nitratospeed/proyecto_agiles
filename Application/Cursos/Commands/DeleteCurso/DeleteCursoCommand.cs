using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cursos.Commands.DeleteCurso
{
    public class DeleteCursoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteCursoCommandHandler : IRequestHandler<DeleteCursoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCursoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCursoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cursos.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Cursos), request.Id);
            }

            //entity.Active = false;

            _context.Cursos.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var result = 1;

            return result;
        }
    }
}
