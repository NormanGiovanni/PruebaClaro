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
        public async Task<IHttpActionResult> Get()
        {
                var model = await _documentos.SeleccionarTodos();
                return Ok(model);
        }

        /// <summary>
        /// Selecciona un tipo de documento
        /// </summary>
        /// <param name="id">Codigo</param>
        /// <returns></returns>
        public TipoDocumentos Get(int id)
        {
            return _documentos.SeleccionarRegistro(id);
        }

        /// <summary>
        /// Inserta tipo de documento
        /// </summary>
        /// <param name="value">Modelo de datos tipo documento</param>
        /// <returns></returns>
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
        public async Task<IHttpActionResult> Put([FromBody] TipoDocumentos value)
        {
            await _documentos.Actualizar(value);
            return Ok();
        }

        /// <summary>
        /// Elimina un tipo de documento
        /// </summary>
        /// <param name="id">Codigo documento</param>
        /// <returns></returns>
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
