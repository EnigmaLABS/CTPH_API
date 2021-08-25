using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using CTPH_CoreData.DataContext;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.Common;
using CTPH_CoreBusiness.BusinessInterface;
using CTPH_CoreBusiness.ActionInterface;

namespace CTPH_CoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestrasController : ControllerBase
    {
        private CTPH_DBContext _context;
        private IElemento _elementos;
        private IPuntoMedida _puntosmedida;
        private Muestra _Muestra;
        private IPerfil _perfil;

        public MuestrasController(CTPH_DBContext context, 
                                  IElemento elementos,
                                  IMuestraAction muestraaction,
                                  IPuntoMedida puntosmedida,
                                  IPerfil perfil)
        {
            _context = context;

            _elementos = elementos;
            _puntosmedida = puntosmedida;
            _Muestra = new Muestra(muestraaction);
            _perfil = perfil;
        }

        // GET: api/<MuestrasController>
        [HttpGet]
        public IEnumerable<IMuestraInfo> Get()
        {
            var result = _Muestra.Get(DateTime.Now.AddDays(-100), DateTime.Now);
            return result;
        }

        // GET api/<MuestrasController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("Muestras/GetElementos")]
        public IEnumerable<IElemento> GetElementos()
        {
            var result = _elementos.Get();
            return result;
        }

        [HttpGet("Muestras/GetElemento_ListaValores")]
        public IEnumerable<IListaValores> GetElemento_ListaValores(int idElemento)
        {
            var result = _elementos.GetListaValores(idElemento);
            return result;
        }

        [HttpGet("Muestras/GetPuntosDeMedida")]
        public IEnumerable<IPuntoMedidaInfo> GetPuntosDeMedida()
        {
            var result = _puntosmedida.Get();
            return result;
        }

        [HttpGet("Muestras/GetPerfiles")]
        public IEnumerable<IPerfil> GetPerfiles()
        {
            var result = _perfil.GetPerfiles();
            return result;
        }

        [HttpGet("Muestras/GetElementos_Perfil")]
        public IEnumerable<IElemento> GetElementos_Perfil(int idPerfil)
        {
            var result = _perfil.GetElementos(idPerfil);
            return result;
        }

        // POST api/<MuestrasController>
        [HttpPost]
        public ResultDTO Post([FromBody] Muestra muestra)
        {
            var result = new ResultDTO();
            return result;
        }

        //// PUT api/<MuestrasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [HttpPut]
        public ResultDTO Insert([FromBody] Muestra muestra)
        {
            var result = _Muestra.Insert(muestra);
            return result;
        }

        //// DELETE api/<MuestrasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
