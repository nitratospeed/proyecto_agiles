using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Certificado
    {
        public int Id { get; set; }
        public string Condicion { get; set; }
        public decimal Costo { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
