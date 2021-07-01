using System.Collections.Generic;
using CTPH_CoreBusiness.BusinessInterface;
using CTPH_CoreData.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace CTPH_CoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private CTPH_DBContext _context;
        private IElemento _elementos;
        private IPuntoMedida _puntosmedida;

        public AdminController(CTPH_DBContext context,
                                  IElemento elementos,
                                  IPuntoMedida puntosmedida)
        {
            _context = context;

            _elementos = elementos;
            _puntosmedida = puntosmedida;
        }

        #region Get Maestros

        [HttpGet("Admin/GetElementos")]
        public IEnumerable<IElemento> GetElementos()
        {
            var result = _elementos.Get();
            return result;
        }

        [HttpGet("Admin/GetElemento_ListaValores")]
        public IEnumerable<IListaValores> GetElemento_ListaValores(int idElemento)
        {
            var result = _elementos.GetListaValores(idElemento);
            return result;
        }

        [HttpGet("Admin/GetPuntosDeMedida")]
        public IEnumerable<IPuntoMedidaInfo> GetPuntosDeMedida()
        {
            var result = _puntosmedida.Get();
            return result;
        }

        #endregion


        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
