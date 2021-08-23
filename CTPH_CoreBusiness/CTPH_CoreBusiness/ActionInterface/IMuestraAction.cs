using System;
using System.Collections.Generic;

using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Common;

namespace CTPH_CoreBusiness.ActionInterface
{
    public interface IMuestraAction
    {
        IEnumerable<Muestra> Get(DateTime dtInicio, DateTime dtFin);
        ResultDTO Insert(Muestra muestra);
    }
}