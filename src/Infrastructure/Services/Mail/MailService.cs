using Application.Common.Interfaces;
using Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        static bool mailSent = false;
        //private readonly IHostingEnvironment _hostingEnvironment;
        //public MailService(IHostingEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //}

        public bool SendEmail(Curso curso, Usuario usuario, string MailFrom, string PasswordFrom)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(MailFrom));
            email.To.Add(MailboxAddress.Parse(usuario.Correo));
            email.Subject = "Bienvenido al curso de " + curso.Nombre;

            var bodyBuilder = new BodyBuilder();

            var pathh = Path.Combine(Directory.GetCurrentDirectory(), "correo.html");

            using (StreamReader SourceReader = File.OpenText(pathh))
            {
                var bodytemp = SourceReader.ReadToEnd();

                bodytemp = bodytemp.Replace("{usuario_nombre}", usuario.Nombres + " " + usuario.Apellidos);
                bodytemp = bodytemp.Replace("$curso_nombre", curso.Nombre);
                bodytemp = bodytemp.Replace("$curso_imagen", curso.UrlImagen);
                bodytemp = bodytemp.Replace("$curso_descripcion", curso.Descripcion);
                bodytemp = bodytemp.Replace("$curso_docente", curso.Docente.Nombre);
                bodytemp = bodytemp.Replace("$curso_link", curso.UrlVideo);

                bodyBuilder.HtmlBody = bodytemp;
            }

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(MailFrom, PasswordFrom);
            smtp.Send(email);
            smtp.Disconnect(true);
            mailSent = true;
            return mailSent;
        }
    }
}
