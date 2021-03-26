using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
