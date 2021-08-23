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
            var res = _context.Muestras.Where(m => m.fhMuestra >= dtInicio && m.fhMuestra <= dtFin);

            List<BusinessObjects.Muestra> list = new List<BusinessObjects.Muestra>();

            foreach (var item in res.ToList())
            {
                list.Add(new BusinessObjects.Muestra()
                {
                    Id = item.idMuestra,
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
                Muestras newmuestra = new Muestras()
                {
                    fhMuestra = DateTime.Now,
                    Observaciones = muestra.Observaciones,
                };

                if (muestra.MuestrasValores != null)
                {
                    foreach (var valores in muestra.MuestrasValores)
                    {
                        newmuestra.Muestras_Valores.Add(new Muestras_Valores()
                        {
                            Temperatura = valores.Temperatura,
                            Humedad = valores.Humedad,

                            idPuntoDeMedidaNavigation = _context.PuntosDeMedida.FirstOrDefault(pm => pm.idPuntoDeMedida == valores.PuntoMedida.idPuntoMedida)
                        }); ;
                    }
                }

                if (muestra.SituacionAmbiente != null && muestra.SituacionAmbiente.Elementos != null)
                {
                    newmuestra.idSituacionAmbienteNavigation = new SituacionAmbiente()
                    {
                        Observaciones = muestra.SituacionAmbiente.Observaciones
                    };
                    newmuestra.idSituacionAmbienteNavigation.SituacionAmbiente_Elementos = new List<SituacionAmbiente_Elementos>();
                }

                _context.Muestras.Add(newmuestra);
                _context.SaveChanges();

                if (muestra.SituacionAmbiente != null && muestra.SituacionAmbiente.Elementos != null)
                {
                    foreach (var elem in muestra.SituacionAmbiente.Elementos)
                    {
                        _context.SituacionAmbiente_Elementos.Add(new SituacionAmbiente_Elementos()
                        {
                            idSituacionAmbiente = (long)newmuestra.idSituacionAmbiente,
                            idElemento = elem.Elemento.idElemento,
                            Valor = elem.Valor,
                            idListaValor = elem.idListaValor
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
