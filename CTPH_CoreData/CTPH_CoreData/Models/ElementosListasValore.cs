using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class ElementosListasValore
    {
        public ElementosListasValore()
        {
            SituacionAmbienteElementos = new HashSet<SituacionAmbienteElemento>();
        }

        public int IdListaValores { get; set; }
        public int? IdElemento { get; set; }
        public string NombreListaValor { get; set; }

        public virtual Elemento IdElementoNavigation { get; set; }
        public virtual ICollection<SituacionAmbienteElemento> SituacionAmbienteElementos { get; set; }
    }
}
