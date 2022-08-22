using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ApiClientes.Controllers
{
    /// <summary>
    /// Client controller
    /// </summary>
    public class ClientesController : ApiController
    {
        /// <summary>
        /// servicio de consumo en db
        /// </summary>
        private Logica.Servicios.ServicesClientes _db;
        /// <summary>
        /// Inicialización clientes
        /// </summary>
        public ClientesController()
        {
            _db = new Logica.Servicios.ServicesClientes();
        }

        /// <summary>
        /// Seleccionar todos los clientes
        /// </summary>
        /// <returns></returns>
        [Route("Clientes/SeleccionarTodos")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var model = await _db.SeleccionarTodos();
                return Ok(model);
            }
            catch
            {

                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                return ResponseMessage(responseMessage);
            }

        }

        /// <summary>
        /// Seleccionar un cliente por codigo
        /// </summary>
        /// <param name="id">Codigo cliente</param>
        /// <returns></returns>
        [Route("Clientes/SeleccionarId")]
        [HttpGet]
        public async Task<IHttpActionResult> SeleccionarId(int id)
        {
            try
            {
                var model = _db.SeleccionarRegistro(id);
                return Ok(model);
            }
            catch
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                return ResponseMessage(responseMessage);
            }
            
        }
        /// <summary>
        /// Insertar clientes
        /// </summary>
        /// <param name="value">Modelo de datos cliente</param>
        /// <returns></returns>
        [Route("Clientes/Crear")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Clientes value)
        {
            try
            {
                await _db.Insertar(value);
                return Ok(HttpStatusCode.Created);
            }
            catch
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return ResponseMessage(responseMessage);
            }
         
        }

        /// <summary>
        /// Actualizar clientes
        /// </summary>
        /// <param name="value">Modelo de datos cliente</param>
        /// <returns></returns>
        [Route("Clientes/Actualizar")]
        [HttpPost]
        public async Task<IHttpActionResult> Actualizar([FromBody] Clientes value)
        {
            try
            {
                await _db.Actualizar(value);
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return ResponseMessage(responseMessage);
            }

        }

        /// <summary>
        /// Eliminar un cliente
        /// </summary>
        /// <param name="id">Codigo clientes</param>
        /// <returns></returns>
        [Route("Clientes/Eliminar")]
        [HttpPost]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await _db.Eliminar(id);
                return Ok(HttpStatusCode.OK);
            }
            catch
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return ResponseMessage(responseMessage);
            }


        }
        /// <summary>
        /// Activar y desactivar el cliente
        /// </summary>
        /// <param name="id">Codigo cliente</param>
        /// <param name="activo">Estado del cliente activo: true, inactivo : false</param>
        /// <returns></returns>
        [Route("Clientes/Activar")]
        public async Task<IHttpActionResult> ActivarCliente(int id, bool activo)
        {
            try
            {
                await _db.CambiarEstadoCliente(id, activo);
                return Ok(HttpStatusCode.Accepted);
            }
            catch
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                return ResponseMessage(responseMessage);
            }

        }
    }
}
