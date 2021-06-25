using System;
using System.Collections.Generic;

using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Common;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IMuestra
    {
        long? Id { get; set; }
        DateTime fhMuestra { get; set; }
        string Observaciones { get; set; }
        List<MuestraValor> MuestrasValores { get; set; }
        SituacionAmbiente SituacionAmbiente { get; set; }

        IEnumerable<Muestra> Get(DateTime dtInicio, DateTime dtFin);

        ResultDTO Insert(Muestra muestra);
    }
}
