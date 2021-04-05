using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CursoUsuario
    {
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
