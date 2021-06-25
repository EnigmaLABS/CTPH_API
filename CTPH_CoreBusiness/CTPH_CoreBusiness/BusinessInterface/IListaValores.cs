using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IListaValores
    {
        Elemento Elemento { get; set; }
        int idListaValor { get; set; }
        string NombreListaValor { get; set; }
    }
}
