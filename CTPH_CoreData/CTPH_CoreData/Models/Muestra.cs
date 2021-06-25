using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class Muestra
    {
        public Muestra()
        {
            MuestrasValores = new HashSet<MuestrasValore>();
        }

        public long IdMuestra { get; set; }
        public DateTime FhMuestra { get; set; }
        public string Observaciones { get; set; }
        public long? IdSituacionAmbiente { get; set; }

        public virtual SituacionAmbiente IdSituacionAmbienteNavigation { get; set; }
        public virtual ICollection<MuestrasValore> MuestrasValores { get; set; }
    }
}
