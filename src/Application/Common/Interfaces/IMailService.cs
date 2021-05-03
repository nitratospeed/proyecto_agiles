using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IMailService
    {
        bool SendEmail(Curso curso, Usuario usuario, string MailFrom, string PasswordFrom);
    }
}
