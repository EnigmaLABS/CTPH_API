using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IElemento
    {
        string Descripcion { get; set; }
        int idElemento { get; set; }
        TipoValor TipoValor { get; set; }

        IEnumerable<Elemento> Get();
        IEnumerable<ListaValores> GetListaValores(int id);
    }
}
