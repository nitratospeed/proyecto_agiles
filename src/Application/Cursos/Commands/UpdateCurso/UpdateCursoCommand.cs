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
        public string Descripcion { get; set; }
        public string TipoAsistencia { get; set; }
        public decimal Precio { get; set; }
        public decimal Calificacion { get; set; }
        public string UrlImagen { get; set; }
        public int DocenteId { get; set; }
        public int CategoriaId { get; set; }
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
            entity.Descripcion = request.Descripcion;
            entity.TipoAsistencia = request.TipoAsistencia;
            entity.Precio = request.Precio;
            entity.Calificacion = request.Calificacion;
            entity.UrlImagen = request.UrlImagen;
            entity.DocenteId = request.DocenteId;
            entity.CategoriaId = request.CategoriaId;

            await _context.SaveChangesAsync(cancellationToken);

            var result = 1;

            return result;
        }
    }
}
