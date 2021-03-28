using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CursoContenido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<CursoContenidoDetalle> CursoContenidoDetalles { get; set; }
    }
}
