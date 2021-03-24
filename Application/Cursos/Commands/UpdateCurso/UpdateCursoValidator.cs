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
            RuleFor(x => x.Nombre)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
