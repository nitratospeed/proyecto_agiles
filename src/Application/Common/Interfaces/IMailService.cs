using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IMailService
    {
        bool SendEmail(string Correo, string Curso, string Nombres, string LinkCurso, string MailFrom, string PasswordFrom);
    }
}
