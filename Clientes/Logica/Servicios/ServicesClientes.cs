using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Servicios
{
    /// <summary>
    /// Clase servicio documentos
    /// </summary>
    public class ServicesClientes : IClientes
    {
        /// <summary>
        /// Acceso a db
        /// </summary>
        private Datos.dbClientes db;
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ServicesClientes()
        {
            db = new Datos.dbClientes();
        }
        /// <summary>
        /// Actualiza el cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Actualizar(Clientes model)
        {
            var old = db.Clientes.SingleOrDefault(b => b.Id == model.Codigo);
            old.Nombre = model.Nombre;
            old.Estado = model.Activo;
            old.Tipo_documento = model.Tipodocumento;
            old.Identificacion = model.Identificacion;
            old.Email = model.Email;
            old.Celular = model.Celular;
            old.Direccion = model.Direccion;
            old.Direccion_de_Instalacion = model.DireccionInstalacion;
            await db.SaveChangesAsync();

        }
        /// <summary>
        /// Elimina un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Eliminar(int id)
        {
            var old = db.Clientes.SingleOrDefault(b => b.Id == id);
            db.Clientes.Remove(old);
            await db.SaveChangesAsync();
        }
        /// <summary>
        /// Inseta un cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Insertar(Clientes model)
        {
            db.Clientes.Add(new Datos.Clientes
            {
                Estado = model.Activo,
                Nombre = model.Nombre,
                Tipo_documento = model.Tipodocumento,
                 Identificacion = model.Identificacion,
                  Email = model.Email,
            Celular = model.Celular,
            Direccion = model.Direccion,
            Direccion_de_Instalacion = model.DireccionInstalacion
        });
            await db.SaveChangesAsync();
        }
        /// <summary>
        /// Selecciona un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Clientes SeleccionarRegistro(int id)
        {
            var dato = db.Clientes.SingleOrDefault(b => b.Id == id);
            var model = new Clientes
            {
                 Activo = dato.Estado,
                  Identificacion= dato.Identificacion,
                   Nombre = dato.Nombre,
                    Tipodocumento = dato.Tipo_documento,
                     Codigo = dato.Id,
                Email = dato.Email,
                Celular = dato.Celular,
                Direccion = dato.Direccion,
                DireccionInstalacion = dato.Direccion_de_Instalacion

            };
            return model;
        }
        /// <summary>
        /// selecciona todos los clientes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Clientes>> SeleccionarTodos()
        {
            var model = await db.Clientes.ToListAsync();
            var lista = from a in model
                        select new Clientes
                        {
                            Activo = a.Estado,
                            Identificacion = a.Identificacion,
                            Nombre = a.Nombre,
                            Tipodocumento = a.Tipo_documento,
                            Codigo = a.Id,
                             Email = a.Email,
                            Celular = a.Celular,
                            Direccion = a.Direccion,
                            DireccionInstalacion = a.Direccion_de_Instalacion
                        };
            return lista;
        }
        /// <summary>
        /// Modifica el estado del cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Activo"></param>
        /// <returns></returns>
        public async Task CambiarEstadoCliente(int id, bool Activo)
        {
            db.CambioEstadoCliente(id, Activo);
            await db.SaveChangesAsync();
        }
        
    }
}
