using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public List<CursoUsuario> CursoUsuarios { get; set; }
        public List<UsuarioTema> UsuarioTemas { get; set; }
    }
}
