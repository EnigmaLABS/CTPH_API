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
            var res = _context.Elementos.Include(tv => tv.IdTipoValorNavigation);

            List<Elemento> list = new List<Elemento>();

            foreach (var item in res)
            {
                list.Add(new Elemento()
                {
                    idElemento = item.IdElemento,
                    Descripcion = item.Elemento1,

                    TipoValor = new TipoValor()
                    {
                        idTipoValor = item.IdTipoValorNavigation.IdTipoValor,
                        Descripcion = item.IdTipoValorNavigation.TipoValor
                    }
                });
            }

            return list;
        }

        public IEnumerable<ListaValores> GetListaValores(int id)
        {
            var res = _context.ElementosListasValores.Include(el => el.IdElementoNavigation).Where(e => e.IdElemento == id);

            List<ListaValores> list = new List<ListaValores>();

            foreach (var item in res)
            {
                list.Add(new ListaValores()
                {
                    idListaValor = item.IdListaValores,
                    NombreListaValor = item.NombreListaValor,

                    Elemento = new Elemento()
                    {
                        idElemento = item.IdElementoNavigation.IdElemento,
                        Descripcion = item.IdElementoNavigation.Elemento1
                    }
                });
            }

            return list;
        }

    }
}
