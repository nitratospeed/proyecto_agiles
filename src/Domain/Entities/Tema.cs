using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Tema
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Curso> Cursos { get; set; }
        public List<UsuarioTema> UsuarioTemas { get; set; }
    }
}
