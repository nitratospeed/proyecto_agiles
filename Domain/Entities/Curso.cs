using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string TipoAsistencia { get; set; }
        public decimal Precio { get; set; }
        public bool BrindaCertificado { get; set; }
        public decimal CostoCertificado { get; set; }
    }
}
