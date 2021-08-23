using System.Collections.Generic;

using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreData.DataContext;

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
    }
}
