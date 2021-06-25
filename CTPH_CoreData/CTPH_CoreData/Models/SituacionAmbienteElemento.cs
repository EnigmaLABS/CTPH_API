using System;
using System.Collections.Generic;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class SituacionAmbienteElemento
    {
        public long IdSituacionAmbienteElementos { get; set; }
        public string Valor { get; set; }
        public int? IdListaValor { get; set; }
        public long IdSituacionAmbiente { get; set; }
        public int IdElemento { get; set; }

        public virtual Elemento IdElementoNavigation { get; set; }
        public virtual ElementosListasValore IdListaValorNavigation { get; set; }
        public virtual SituacionAmbiente IdSituacionAmbienteNavigation { get; set; }
    }
}
