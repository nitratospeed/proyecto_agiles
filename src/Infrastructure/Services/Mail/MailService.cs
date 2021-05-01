using Application.Common.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        static bool mailSent = false;
        public bool SendEmail(string Correo, string Curso, string Nombres, string LinkCurso, string MailFrom, string PasswordFrom)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(MailFrom));
            email.To.Add(MailboxAddress.Parse(Correo));
            email.Subject = "Bienvenido al curso de " + Curso;
            email.Body = new TextPart(TextFormat.Html) { Text = 
                "<h1>Te damos la bienvenida al curso de "+Curso+"</h1>" +
                "<a href='" + LinkCurso + "'>Podrás ingresar al curso aquí</a>" +
                "<p>Ágiles 2021</p>"};

            // send email
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
