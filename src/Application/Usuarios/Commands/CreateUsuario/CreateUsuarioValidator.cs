using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(x => x.Nombres)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(x => x.Apellidos)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(x => x.Correo)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(x => x.Contrasena)
                .MaximumLength(250)
                .NotEmpty();
        }
    }
}
