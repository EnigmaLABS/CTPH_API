using CTPH_CoreBusiness.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.ActionInterface
{
    public interface IElementoAction
    {
        IEnumerable<Elemento> Get();

        IEnumerable<ListaValores> GetListaValores(int id);
    }
}
