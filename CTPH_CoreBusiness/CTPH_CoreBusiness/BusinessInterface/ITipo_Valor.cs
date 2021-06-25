using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public enum enumTipoValor { Numero = 1, Texto = 2, Lista = 3, Si_No = 4 }

    public interface ITipoValor
    {
        byte idTipoValor { get; set; }

        string Descripcion { get; set; }

        enumTipoValor GetTipoValor();
    }
}
