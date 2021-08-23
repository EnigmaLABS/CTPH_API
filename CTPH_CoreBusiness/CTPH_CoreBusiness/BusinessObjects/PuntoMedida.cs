using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using CTPH_CoreData.DataContext;
using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class PuntoMedida : IPuntoMedida, IPuntoMedidaInfo
    {
        private CTPH_DBContext _context;

        public PuntoMedida() {  }

        public PuntoMedida(CTPH_DBContext context)
        {
            _context = context;
        }

        public int idPuntoMedida { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public TiposPuntoMedida TipoPuntoMedida { get; set; }


        //-->>
        #region  Métodos

        public IEnumerable<PuntoMedida> Get()
        {
            var res = _context.PuntosDeMedida.Include(tpm => tpm.idTipoPuntoDeMedidaNavigation);

            List<PuntoMedida> list = new List<PuntoMedida>();

            foreach (var item in res)
            {
                list.Add(new PuntoMedida()
                {
                    idPuntoMedida = item.idPuntoDeMedida,
                    Descripcion = item.Descripcion,
                    Observaciones = item.Observaciones,

                    TipoPuntoMedida = new TiposPuntoMedida()
                    {
                        idTipoPuntoMedida = item.idTipoPuntoDeMedidaNavigation.idTipoPuntoDeMedida,
                        Descripcion = item.idTipoPuntoDeMedidaNavigation.Descripcion
                    }
                });
            }

            return list;
        }

        #endregion

    }
}
