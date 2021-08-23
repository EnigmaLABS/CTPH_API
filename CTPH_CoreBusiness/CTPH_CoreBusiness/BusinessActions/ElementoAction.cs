using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Enums;
using CTPH_CoreData.DataContext;

namespace CTPH_CoreBusiness.BusinessActions
{
    public class ElementoAction : IElementoAction
    {
        private CTPH_DBContext _context;

        public ElementoAction(CTPH_DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Elemento> Get()
        {
            var res = _context.Elementos.Include(tv => tv.idTipoValorNavigation);

            List<Elemento> list = new List<Elemento>();

            foreach (var item in res)
            {
                list.Add(new Elemento()
                {
                    idElemento = item.idElemento,
                    Descripcion = item.Elemento,

                    TipoValor = new TipoValor()
                    {
                        idTipoValor = item.idTipoValorNavigation.idTipoValor,
                        Descripcion = item.idTipoValorNavigation.TipoValor
                    }
                });
            }

            return list;
        }

        public IEnumerable<ListaValores> GetListaValores(int id)
        {
            var res = _context.Elementos_Listas_Valores.Include(el => el.idElementoNavigation).Where(e => e.idElemento == id);

            List<ListaValores> list = new List<ListaValores>();

            foreach (var item in res)
            {
                list.Add(new ListaValores()
                {
                    idListaValor = item.idListaValores,
                    NombreListaValor = item.NombreListaValor,

                    Elemento = new Elemento()
                    {
                        idElemento = item.idElementoNavigation.idElemento,
                        Descripcion = item.idElementoNavigation.Elemento
                    }
                });
            }

            return list;
        }

    }
}
