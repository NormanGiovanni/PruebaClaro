using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
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
        public async Task<IHttpActionResult> Get()
        {
            var model = await _db.SeleccionarTodos();
            return Ok(model);
        }

        /// <summary>
        /// Seleccionar un cliente por codigo
        /// </summary>
        /// <param name="id">Codigo cliente</param>
        /// <returns></returns>
        [Route("Clientes/SeleccionarId")]
        public Clientes SeleccionarId(int id)
        {
            return _db.SeleccionarRegistro(id);
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
            await _db.Insertar(value);
            return Ok();
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
            await _db.Actualizar(value);
            return Ok();
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
            await _db.Eliminar(id);
            return Ok();

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
            await _db.CambiarEstadoCliente(id,activo);
            return Ok();
        }
    }
}
