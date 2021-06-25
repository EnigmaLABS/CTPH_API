using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class MuestrasValore
    {
        public long IdMuestra { get; set; }
        public int IdPuntoDeMedida { get; set; }
        public decimal? Temperatura { get; set; }
        public byte? Humedad { get; set; }

        public virtual Muestra IdMuestraNavigation { get; set; }
        public virtual PuntosDeMedidum IdPuntoDeMedidaNavigation { get; set; }
    }
}
