using System.Collections.Generic;

using CTPH_CoreBusiness.BusinessObjects;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IPerfil
    {
        List<Elemento> Elementos { get; set; }
        int idPerfil { get; set; }
        IEnumerable<Perfil> GetPerfiles();
    }
}