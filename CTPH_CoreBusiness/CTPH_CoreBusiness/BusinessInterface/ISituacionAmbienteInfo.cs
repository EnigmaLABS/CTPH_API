using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface ISituacionAmbienteInfo
    {
        long? idSituacionAmbiente { get; set; }

        List<ElementoValor> Elementos { get; set; }

        string Observaciones { get; set; }
    }
}
