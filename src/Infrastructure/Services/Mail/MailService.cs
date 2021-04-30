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
        public bool SendEmail(string Correo, string Curso, string Nombres, string LinkCurso)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("u201817688@upc.edu.pe"));
            email.To.Add(MailboxAddress.Parse(Correo));
            email.Subject = "Bienvenido al curso de " + Curso; //<a href="http://">Accede al curso aquí</a>
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>"+Curso+"</h1>" + "<a href='" + LinkCurso + "'>"+Curso+"</a>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("u201817688@upc.edu.pe", "Discovery21!");
            smtp.Send(email);
            smtp.Disconnect(true);
            mailSent = true;
            return mailSent;
        }
    }
}
