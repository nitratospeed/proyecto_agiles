using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cursos.Commands.CreateCurso
{
    public class CreateCursoCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoAsistencia { get; set; }
        public decimal Precio { get; set; }
        public decimal Calificacion { get; set; }
        public string UrlImagen { get; set; }
        public int DocenteId { get; set; }
        public int CategoriaId { get; set; }
        public int TemaId { get; set; }
    }

    public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCursoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCursoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Curso
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                TipoAsistencia = request.TipoAsistencia,
                Precio = request.Precio,
                Calificacion = request.Calificacion,
                UrlImagen = request.UrlImagen,
                DocenteId = request.DocenteId,
                CategoriaId = request.CategoriaId,
                TemaId = request.TemaId
            };

            _context.Cursos.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
