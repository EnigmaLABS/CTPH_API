using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class SituacionAmbiente
    {
        public SituacionAmbiente()
        {
            Muestras = new HashSet<Muestra>();
            SituacionAmbienteElementos = new HashSet<SituacionAmbienteElemento>();
        }

        public long IdSituacionAmbiente { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<Muestra> Muestras { get; set; }
        public virtual ICollection<SituacionAmbienteElemento> SituacionAmbienteElementos { get; set; }
    }
}
