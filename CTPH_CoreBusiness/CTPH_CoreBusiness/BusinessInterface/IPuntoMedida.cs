using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IPuntoMedida
    {
        string Descripcion { get; set; }
        int idPuntoMedida { get; set; }
        string Observaciones { get; set; }
        TiposPuntoMedida TipoPuntoMedida { get; set; }
        IEnumerable<PuntoMedida> Get();
    }
}
