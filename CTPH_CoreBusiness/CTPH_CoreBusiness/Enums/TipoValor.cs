using CTPH_CoreBusiness.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.Enums
{
    public class TipoValor : ITipoValor
    {
        public byte idTipoValor { get; set; }

        public string Descripcion { get; set; }

        public enumTipoValor GetTipoValor()
        {
            return (enumTipoValor)this.idTipoValor;
        }
    }
}
