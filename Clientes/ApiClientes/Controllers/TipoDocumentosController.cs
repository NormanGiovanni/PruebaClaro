using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiClientes.Controllers
{
    public class TipoDocumentosController : ApiController
    {
        private Logica.Servicios.ServicesTipoDocumentos _documentos;
       
        public TipoDocumentosController()
        {
            _documentos = new Logica.Servicios.ServicesTipoDocumentos();
           
        }

        // GET: api/TipoDocumentos
        public async Task<IHttpActionResult> Get()
        {
                var model = await _documentos.SeleccionarTodos();
                return Ok(model);
        }

        // GET: api/TipoDocumentos/5
        public TipoDocumentos Get(int id)
        {
            return _documentos.SeleccionarRegistro(id);
        }

        // POST: api/TipoDocumentos
        public async Task<IHttpActionResult> Post([FromBody] TipoDocumentos value)
        {
           await _documentos.Insertar(value);
            return Ok();
        }

        // PUT: api/TipoDocumentos/5
        public async Task<IHttpActionResult> Put([FromBody] TipoDocumentos value)
        {
            await _documentos.Actualizar(value);
            return Ok();
        }

        // DELETE: api/TipoDocumentos/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await _documentos.Eliminar(id);
                return Ok();
            }
            catch
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotModified);
                return ResponseMessage(responseMessage);
                
            }
           

        }
    }
}
