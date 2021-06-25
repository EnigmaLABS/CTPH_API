using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.Common;
using CTPH_CoreData.DataContext;
using CTPH_CoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTPH_CoreBusiness.BusinessActions
{
    public class MuestraAction : IMuestraAction
    {
        private CTPH_DBContext _context;

        public MuestraAction(CTPH_DBContext context)
        {
            _context = context;
        }

        public IEnumerable<BusinessObjects.Muestra> Get(DateTime dtInicio, DateTime dtFin)
        {
            var res = _context.Muestras.Where(m => m.FhMuestra >= dtInicio && m.FhMuestra <= dtFin);

            List<BusinessObjects.Muestra> list = new List<BusinessObjects.Muestra>();

            foreach (var item in res.ToList())
            {
                list.Add(new BusinessObjects.Muestra()
                {
                    Id = item.IdMuestra,
                    Observaciones = item.Observaciones
                });
            }

            return list;
        }

        public ResultDTO Insert(BusinessObjects.Muestra muestra)
        {
            ResultDTO res = new ResultDTO();

            try
            {
                Muestra newmuestra = new Muestra()
                {
                    FhMuestra = DateTime.Now,
                    Observaciones = muestra.Observaciones,
                };

                if (muestra.MuestrasValores != null)
                {
                    foreach (var valores in muestra.MuestrasValores)
                    {
                        newmuestra.MuestrasValores.Add(new MuestrasValore()
                        {
                            Temperatura = valores.Temperatura,
                            Humedad = valores.Humedad,

                            IdPuntoDeMedidaNavigation = _context.PuntosDeMedida.FirstOrDefault(pm => pm.IdPuntoDeMedida == valores.PuntoMedida.idPuntoMedida)
                        }); ;
                    }
                }

                if (muestra.SituacionAmbiente != null && muestra.SituacionAmbiente.Elementos != null)
                {
                    newmuestra.IdSituacionAmbienteNavigation = new SituacionAmbiente()
                    {
                        Observaciones = muestra.SituacionAmbiente.Observaciones
                    };
                    newmuestra.IdSituacionAmbienteNavigation.SituacionAmbienteElementos = new List<SituacionAmbienteElemento>();
                }

                _context.Muestras.Add(newmuestra);
                _context.SaveChanges();

                if (muestra.SituacionAmbiente != null && muestra.SituacionAmbiente.Elementos != null)
                {
                    foreach (var elem in muestra.SituacionAmbiente.Elementos)
                    {
                        _context.SituacionAmbienteElementos.Add(new SituacionAmbienteElemento()
                        {
                            IdSituacionAmbiente = (long)newmuestra.IdSituacionAmbiente,
                            IdElemento = elem.Elemento.idElemento,
                            Valor = elem.Valor,
                            IdListaValor = elem.idListaValor
                        });
                    }

                    _context.SaveChanges();
                }

                res.OK = true;
                res.Mensaje = "ok";
            }
            catch (Exception ex)
            {
                res.OK = false;
                res.Mensaje = ex.Message;
            }

            return res;
        }
    }
}
