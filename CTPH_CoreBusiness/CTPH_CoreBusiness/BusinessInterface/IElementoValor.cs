using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IElementoValor
    {
        Elemento Elemento { get; set; }

        string Valor { get; set; }

        int? idListaValor { get; set; }
    }
}
