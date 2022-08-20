using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiClientes.Controllers
{
    public class ClientesController : ApiController
    {
        private Logica.Servicios.ServicesClientes _db;
        public ClientesController()
        {
            _db = new Logica.Servicios.ServicesClientes();
        }

        // GET: api/TipoDocumentos
        public async Task<IHttpActionResult> Get()
        {
            var model = await _db.SeleccionarTodos();
            return Ok(model);
        }

        // GET: api/TipoDocumentos/5
        public Clientes Get(int id)
        {
            return _db.SeleccionarRegistro(id);
        }

        // POST: api/TipoDocumentos
        public async Task<IHttpActionResult> Post([FromBody] Clientes value)
        {
            await _db.Insertar(value);
            return Ok();
        }

        // PUT: api/TipoDocumentos/5
        public async Task<IHttpActionResult> Put([FromBody] Clientes value)
        {
            await _db.Actualizar(value);
            return Ok();
        }

        // DELETE: api/TipoDocumentos/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _db.Eliminar(id);
            return Ok();

        }
        public async Task<IHttpActionResult> ActivarCliente(int id, bool activo)
        {
            await _db.CambiarEstadoCliente(id,activo);
            return Ok();
        }
    }
}
