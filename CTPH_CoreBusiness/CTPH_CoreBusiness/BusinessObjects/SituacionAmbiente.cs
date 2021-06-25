using System;
using System.Collections.Generic;

using CTPH_CoreData.DataContext;
using CTPH_CoreBusiness.BusinessObjects;
using Newtonsoft.Json;
using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class SituacionAmbiente : ISituacionAmbiente, ISituacionAmbienteInfo
    {
        private CTPH_DBContext _context;

        public SituacionAmbiente() {  }

        public SituacionAmbiente(CTPH_DBContext context)
        {
            _context = context;
        }


        public long? idSituacionAmbiente { get; set; }
        public List<ElementoValor> Elementos { get; set; }
        public string Observaciones { get; set; }
    }
}
