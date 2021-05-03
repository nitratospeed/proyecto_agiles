using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mail.Commands.SendEmail
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty();

            RuleFor(x => x.CursoId)
                .NotEmpty();

            RuleFor(x => x.MailFrom)
                .NotEmpty();

            RuleFor(x => x.PasswordFrom)
                .NotEmpty();
        }
    }
}
