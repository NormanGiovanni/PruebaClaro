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
    /// <summary>
    /// Tipo documentos controller
    /// </summary>
    public class TipoDocumentosController : ApiController
    {
        /// <summary>
        /// Servicio de consumo a base de datos
        /// </summary>
        private Logica.Servicios.ServicesTipoDocumentos _documentos;
       /// <summary>
       /// Inicializacion del controlador para el cargue del servicio
       /// </summary>
        public TipoDocumentosController()
        {
            _documentos = new Logica.Servicios.ServicesTipoDocumentos();
           
        }

        /// <summary>
        /// Selecciona todos los tipos de documento
        /// </summary>
        /// <returns></returns>
        [Route("TipoDocumentos/SeleccionarTodos")]
        public async Task<IHttpActionResult> Seleccionar()
        {
                var model = await _documentos.SeleccionarTodos();
                return Ok(model);
        }

        /// <summary>
        /// Selecciona un tipo de documento
        /// </summary>
        /// <param name="id">Codigo</param>
        /// <returns></returns>
        [Route("TipoDocumentos/SeleccionarRegistroId")]
        public TipoDocumentos SeleccionarRegistroId(int id)
        {
            return _documentos.SeleccionarRegistro(id);
        }

        /// <summary>
        /// Inserta tipo de documento
        /// </summary>
        /// <param name="value">Modelo de datos tipo documento</param>
        /// <returns></returns>
        [Route("TipoDocumentos/Crear")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] TipoDocumentos value)
        {
           await _documentos.Insertar(value);
            return Ok();
        }

        /// <summary>
        /// Actualiza tipo de documento
        /// </summary>
        /// <param name="value">Modelo de datos</param>
        /// <returns></returns>
        [Route("TipoDocumentos/Actualizar")]
        [HttpPost]
        public async Task<IHttpActionResult> Actualizar([FromBody] TipoDocumentos value)
        {
            await _documentos.Actualizar(value);
            return Ok();
        }

        /// <summary>
        /// Elimina un tipo de documento
        /// </summary>
        /// <param name="id">Codigo documento</param>
        /// <returns></returns>
        [Route("TipoDocumentos/Eliminar")]
        [HttpPost]
        public async Task<IHttpActionResult> Eliminar(int id)
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
