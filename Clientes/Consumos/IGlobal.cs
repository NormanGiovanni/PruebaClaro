using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consumos
{
    public interface IGlobal
    {
        /// <summary>
        /// Seleccionar todos los registros
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint">Enpoint y apuntamiento a la api</param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> Seleccionar<T>(string endpoint);
        /// <summary>
        /// Consultar un registro por su id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> SeleccionarRegistro<T>(string endpoint, long key);
        /// <summary>
        /// Insertar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        Task Insertar<T>(T model, string endpoint);
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        Task Actualizar<T>(T model, string endpoint);
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        Task Eliminar(long key, string endpoint);
        /// <summary>
        /// Seleccionar varios registros basados en un key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SeleccionarRegistros<T>(string endpoint, long key);
    }
}
