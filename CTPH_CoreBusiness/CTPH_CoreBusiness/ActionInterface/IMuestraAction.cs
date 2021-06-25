using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Common;
using System;
using System.Collections.Generic;

namespace CTPH_CoreBusiness.ActionInterface
{
    public interface IMuestraAction
    {
        IEnumerable<Muestra> Get(DateTime dtInicio, DateTime dtFin);
        ResultDTO Insert(Muestra muestra);
    }
}