using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UsuarioTema
    {
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
