using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class TiposPuntosDeMedidum
    {
        public TiposPuntosDeMedidum()
        {
            PuntosDeMedida = new HashSet<PuntosDeMedidum>();
        }

        public byte IdTipoPuntoDeMedida { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PuntosDeMedidum> PuntosDeMedida { get; set; }
    }
}
