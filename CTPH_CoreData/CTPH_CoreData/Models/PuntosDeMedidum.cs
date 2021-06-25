using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class PuntosDeMedidum
    {
        public PuntosDeMedidum()
        {
            MuestrasValores = new HashSet<MuestrasValore>();
        }

        public int IdPuntoDeMedida { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public byte? IdTipoPuntoDeMedida { get; set; }

        public virtual TiposPuntosDeMedidum IdTipoPuntoDeMedidaNavigation { get; set; }
        public virtual ICollection<MuestrasValore> MuestrasValores { get; set; }
    }
}
