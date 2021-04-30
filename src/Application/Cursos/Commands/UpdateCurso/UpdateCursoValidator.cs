using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cursos.Commands.UpdateCurso
{
    public class UpdateCursoValidator : AbstractValidator<UpdateCursoCommand>
    {
        public UpdateCursoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Nombre)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Descripcion)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(x => x.TipoAsistencia)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Precio)
                .NotEmpty();

            RuleFor(x => x.Calificacion)
                .InclusiveBetween(0, 5)
                .NotEmpty();

            RuleFor(x => x.UrlImagen)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(x => x.DocenteId)
                .NotEmpty();

            RuleFor(x => x.CategoriaId)
                .NotEmpty();

            RuleFor(x => x.TemaId)
                .NotEmpty();
        }
    }
}
