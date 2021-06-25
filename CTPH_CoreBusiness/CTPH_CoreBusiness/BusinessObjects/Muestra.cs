using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.BusinessInterface;
using CTPH_CoreBusiness.Common;
using System;
using System.Collections.Generic;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class Muestra : IMuestra, IMuestraInfo
    {
        private IMuestraAction _DoAction;

        public Muestra() {  }

        public Muestra(IMuestraAction muestraAction)
        {
            _DoAction = muestraAction;
        }

        public long? Id { get; set; }
        public DateTime fhMuestra { get; set; }
        public string Observaciones { get; set; }
        public SituacionAmbiente SituacionAmbiente { get; set; }
        public List<MuestraValor> MuestrasValores { get; set; }

        //-->>
        #region Métodos

        public IEnumerable<Muestra> Get(DateTime dtInicio, DateTime dtFin)
        {
            return _DoAction.Get(dtInicio, dtFin);
        }

        public ResultDTO Insert(Muestra muestra)
        {
            return _DoAction.Insert(muestra); 
        }

        #endregion
    }
}
