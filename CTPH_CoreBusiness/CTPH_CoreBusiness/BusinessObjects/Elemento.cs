using System.Collections.Generic;

using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.Enums;
using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class Elemento : IElemento
    {
        private IElementoAction _DoAction;

        public Elemento() { }

        public Elemento(IElementoAction DoAction)
        {
            _DoAction = DoAction;
        }


        public int idElemento { get; set; }
        public string Descripcion { get; set; }
        public TipoValor TipoValor { get; set; } = new TipoValor();


        //-->>
        #region Métodos

        public IEnumerable<Elemento> Get()
        {
            return _DoAction.Get();
        }

        public IEnumerable<ListaValores> GetListaValores(int id)
        {
            return _DoAction.GetListaValores(id);
        }

        #endregion
    }
}
