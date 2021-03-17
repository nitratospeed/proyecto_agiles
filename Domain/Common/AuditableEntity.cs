using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime FechaCreacion { get; set; }

        public string CreatedPor { get; set; }

        public DateTime? UltimaModificacion { get; set; }

        public string ModificadoPor { get; set; }
    }
}
