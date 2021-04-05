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
        public string TipoAsistencia { get; set; }
        public decimal Precio { get; set; }
        public decimal Calificacion { get; set; }
        public string UrlImagen { get; set; }

        public int DocenteId { get; set; }
        public Docente Docente { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public List<CursoContenido> CursoContenidos { get; set; }

        public Certificado Certificado { get; set; }

        public List<CursoUsuario> CursoUsuarios { get; set; }
    }
}
