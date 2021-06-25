using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IMuestraValor
    {
        byte? Humedad { get; set; }
        decimal? Temperatura { get; set; }
        PuntoMedida PuntoMedida { get; set; }
    }
}
