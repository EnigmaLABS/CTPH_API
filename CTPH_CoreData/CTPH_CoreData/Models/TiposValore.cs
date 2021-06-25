using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class TiposValore
    {
        public TiposValore()
        {
            Elementos = new HashSet<Elemento>();
        }

        public byte IdTipoValor { get; set; }
        public string TipoValor { get; set; }

        public virtual ICollection<Elemento> Elementos { get; set; }
    }
}
