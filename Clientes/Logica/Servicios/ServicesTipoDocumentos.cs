using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Servicios
{
    public class ServicesTipoDocumentos : ITipoDocumentos
    {
        private Datos.dbClientes db;
        public ServicesTipoDocumentos()
        {
            db = new Datos.dbClientes();
        }

        public async Task Actualizar(TipoDocumentos model)
        {
            var old = db.TipoDocumentos.SingleOrDefault(b => b.Id == model.Codigo);
            old.Descripcion = model.Descripcion;
            old.Activo = model.Activo;
            await db.SaveChangesAsync();

        }

        public async Task Eliminar(int id)
        {
                var old = db.TipoDocumentos.SingleOrDefault(b => b.Id == id);
                db.TipoDocumentos.Remove(old);
                await db.SaveChangesAsync();
            
        }

        public async Task Insertar(TipoDocumentos model)
        {
            db.TipoDocumentos.Add(new Datos.TipoDocumentos
            {
                Id = model.Codigo,
                Activo = model.Activo,
                Descripcion = model.Descripcion
            });
            await db.SaveChangesAsync();
        }

        public TipoDocumentos SeleccionarRegistro(int id)
        {
            var dato = db.TipoDocumentos.SingleOrDefault(b => b.Id == id);
            return new TipoDocumentos
            {
                Activo = dato.Activo,
                Codigo = dato.Id,
                Descripcion = dato.Descripcion

            };   
        }

        public async Task<IEnumerable<TipoDocumentos>> SeleccionarTodos()
        {
            var model = await db.TipoDocumentos.ToListAsync();
            var lista = from a in model
                        select new TipoDocumentos
                        {
                            Activo = a.Activo,
                            Codigo = a.Id,
                             Descripcion = a.Descripcion
                        };
            return lista;
        }

        
    }
}
