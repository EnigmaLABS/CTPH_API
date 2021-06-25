using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface ITiposPuntoMedida
    {
        short idTipoPuntoMedida { get; set; }

        string Descripcion { get; set; }
    }
}
