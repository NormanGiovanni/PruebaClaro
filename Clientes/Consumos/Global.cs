using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Consumos
{
    public class Global : IGlobal
    {
        public readonly HttpClient httpClient;
        public Global()
        {
            httpClient = new HttpClient();
        }
        /// <summary>
        /// Llamado api para actualizar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public async Task Actualizar<T>(T model, string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
                var dato = JsonConvert.SerializeObject(model);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(dato, Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }


        }
        /// <summary>
        /// Llamado api para eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public async Task Eliminar(long id, string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, endpoint + id);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
        /// <summary>
        /// Llamado api para insertar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public async Task Insertar<T>(T model, string endpoint)
        {
            try
            {
                var dato = JsonConvert.SerializeObject(model);
                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(dato, Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
        /// <summary>
        /// Llamado api 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<T>> Seleccionar<T>(string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
            catch(Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
        public async Task<T> SeleccionarSimpleObject<T>(string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
        public async Task<string> SeleccionarJson(string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }

        public async Task<T> SeleccionarRegistro<T>(string endpoint,long key)
        {
            string content = string.Empty;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint + key);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                content = await response.Content.ReadAsStringAsync();
                var dato = JsonConvert.DeserializeObject<T>(content);
                return dato;
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
        public async Task<IEnumerable<T>> SeleccionarRegistros<T>(string endpoint, long key)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint + key);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var dato = JsonConvert.DeserializeObject<List<T>>(content);
                return dato;
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
        /// <summary>
        /// Cambiar estado de un registro de entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="endpoint"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public async Task Estado(long key,bool estado, string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, endpoint + key + "?activo=" + estado);
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string mensaje = $"Error consumiendo el endpoint {endpoint} Detalle Error: {ex.Message} ";
                throw new Exception(mensaje);
            }

        }
    }
}
