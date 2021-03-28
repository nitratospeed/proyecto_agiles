using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CursoContenidoDetalle
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UrlVideo { get; set; }
        public int CursoContenidoId { get; set; }
        public CursoContenido CursoContenido { get; set; }
    }
}
