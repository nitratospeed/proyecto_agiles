using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cursos.Commands.CreateCurso
{
    public class CreateCursoValidator : AbstractValidator<CreateCursoCommand>
    {
        public CreateCursoValidator()
        {
            RuleFor(x => x.Nombre)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
