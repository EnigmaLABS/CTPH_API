using System.Collections.Generic;

using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class Perfil : IPerfil
    {
        private IPerfil_Action _perfilAction;

        public Perfil(IPerfil_Action perfilAction)
        {
            _perfilAction = perfilAction;
        }

        public int idPerfil { get; set; }

        public string Descripcion { get; set; }

        public List<Elemento> Elementos { get; set; }

        //-->> Métodos
        public IEnumerable<Perfil> GetPerfiles()
        {
            var result = _perfilAction.GetPerfiles();
            return result;
        }
    }
}
