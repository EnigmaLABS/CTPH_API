using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class Elemento
    {
        public Elemento()
        {
            ElementosListasValores = new HashSet<ElementosListasValore>();
            SituacionAmbienteElementos = new HashSet<SituacionAmbienteElemento>();
        }

        public int IdElemento { get; set; }
        public string Elemento1 { get; set; }
        public byte IdTipoValor { get; set; }

        public virtual TiposValore IdTipoValorNavigation { get; set; }
        public virtual ICollection<ElementosListasValore> ElementosListasValores { get; set; }
        public virtual ICollection<SituacionAmbienteElemento> SituacionAmbienteElementos { get; set; }
    }
}
