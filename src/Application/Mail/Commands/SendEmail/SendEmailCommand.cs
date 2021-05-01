using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mail.Commands.SendEmail
{
    public class SendEmailCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public string MailFrom { get; set; }
        public string PasswordFrom { get; set; }
    }

    public class SendEmailQueryHandler : IRequestHandler<SendEmailCommand, bool>
    {
        private readonly IMailService mailService;
        private readonly IApplicationDbContext context;

        public SendEmailQueryHandler(IMailService mailService, IApplicationDbContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }

        public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var usuario = await context.Usuarios.FindAsync(request.UsuarioId);
            var curso = await context.Cursos.FindAsync(request.CursoId);

            return mailService.SendEmail(usuario.Correo, curso.Nombre, usuario.Nombres + " " + usuario.Apellidos, curso.UrlVideo, request.MailFrom, request.PasswordFrom);
        }
    }
}
