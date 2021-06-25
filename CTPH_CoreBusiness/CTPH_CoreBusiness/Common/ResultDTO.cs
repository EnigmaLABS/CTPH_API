using System;
using System.Collections.Generic;
using System.Text;

namespace CTPH_CoreBusiness.Common
{
    public class ResultDTO : IResultDTO
    {
        public bool OK { get; set; }

        public string Mensaje { get; set; }
    }
}
