using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Servicios
{
    public interface IClientes
    {
        /// <summary>
        /// Seleccionar Todos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<Clientes>> SeleccionarTodos();
        /// <summary>
        /// Insertar
        /// </summary>
        /// <typeparam name="TipoDocumentos"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Insertar(Clientes model);
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Actualizar(Clientes model);
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Eliminar(int id);
    }
}
