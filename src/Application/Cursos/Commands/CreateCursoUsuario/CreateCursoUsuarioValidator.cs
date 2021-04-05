using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cursos.Commands.CreateCursoUsuario
{
    public class CreateCursoUsuarioValidator : AbstractValidator<CreateCursoUsuarioCommand>
    {
        public CreateCursoUsuarioValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty();

            RuleFor(x => x.UsuarioId)
                .NotEmpty();
        }
    }
}
