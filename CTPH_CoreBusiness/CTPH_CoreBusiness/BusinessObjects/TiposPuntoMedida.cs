using CTPH_CoreBusiness.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class TiposPuntoMedida : ITiposPuntoMedida
    {
        public short idTipoPuntoMedida { get; set; }
        public string Descripcion { get; set; }
    }
}
