using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IMuestraInfo
    {
        long? Id { get; set; }

        DateTime fhMuestra { get; set; }

        string Observaciones { get; set; }

        List<MuestraValor> MuestrasValores { get; set; }

        SituacionAmbiente SituacionAmbiente { get; set; }
    }
}
