using System.Collections.Generic;
using System.Linq;
using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Enums;
using CTPH_CoreData.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CTPH_CoreBusiness.BusinessActions
{
    public class Perfil_Action : IPerfil_Action
    {
        private CTPH_DBContext _context;

        public Perfil_Action(CTPH_DBContext context)
        {
            _context = context;
        }

        public List<Perfil> GetPerfiles()
        {
            List<Perfil> result = new List<Perfil>();

            foreach (var perfil in _context.Perfiles)
            {
                result.Add(new Perfil(new Perfil_Action(_context))
                {
                    idPerfil = perfil.idPerfil,
                    Descripcion = perfil.Perfil
                });
            }
            return result;
        }

        public List<Elemento> GetElementos(int idPerfil)
        {
            List<Elemento> result = new List<Elemento>();

            var perfilElems = _context.Perfiles.Where(p => p.idPerfil == idPerfil)
                                                .Include(pe => pe.Perfil_Elementos)
                                                .ThenInclude(elem => elem.idElementoNavigation)
                                                .ThenInclude(tv => tv.idTipoValorNavigation)
                                                .First();


            foreach (var elem in perfilElems.Perfil_Elementos)
            {
                TipoValor tipoValor = new TipoValor()
                {
                    idTipoValor = elem.idElementoNavigation.idTipoValorNavigation.idTipoValor,
                    Descripcion = elem.idElementoNavigation.idTipoValorNavigation.TipoValor
                };

                Elemento newelem = new Elemento(new ElementoAction(_context))
                {
                    idElemento = elem.idElemento,
                    Descripcion = elem.idElementoNavigation.Elemento,
                    TipoValor = tipoValor
                };

                result.Add(newelem);
            }

            return result;
        }
    }
}
