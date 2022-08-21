using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Clientes.Controllers
{
    public class TipoDocumentosController : Controller
    {
        /// <summary>
        /// Intancia clase global para consumos de api
        /// </summary>
        private Consumos.Global _apiConsulta;
        /// <summary>
        /// Variable de api base para consumos optenida desde el web config propiedad UrlApiBase
        /// </summary>
        string ApiBase = string.Empty;
        /// <summary>
        /// Constructor de la clase tipo documentos
        /// </summary>
        public TipoDocumentosController()
        {
            _apiConsulta = new Consumos.Global();
            ApiBase = System.Configuration.ConfigurationManager.AppSettings.Get("UrlApiBase");
        }
        /// <summary>
        /// Vista de inicio de documentos
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string mensaje)
        {
            if(!string.IsNullOrEmpty(mensaje))
            {
                if(mensaje.Contains("Error"))
                ViewBag.Error = mensaje;
                if (mensaje.Contains("registro"))
                    ViewBag.Ok = mensaje;
            }
                
            var model = await _apiConsulta.Seleccionar<Consumos.Modelos.ModelTipoDocumentos>($"{ApiBase}/api/TipoDocumentos");
            
            return View(model);
        }
       /// <summary>
       /// Inserta o actualiza documento
       /// </summary>
       /// <param name="model"></param>
       /// <param name="frm"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Guardar(Consumos.Modelos.ModelTipoDocumentos model,FormCollection frm)
        {
            try
            {
                var Activo = frm["Activo"];
                if (Activo == "on")
                    model.Activo = true;
                var old = await _apiConsulta.SeleccionarRegistro<Consumos.Modelos.ModelTipoDocumentos>($"{ApiBase}/api/TipoDocumentos/",model.Codigo);
                if (old != null)
                    await _apiConsulta.Actualizar(model, $"{ApiBase}/api/TipoDocumentos");
                
                return RedirectToAction("Index", new { mensaje = "El registro ha sido modficado exitosamente" });
            }
            catch
            {
                try
                {
                    model.Activo = true;
                    await _apiConsulta.Insertar(model, $"{ApiBase}/api/TipoDocumentos");
                    return RedirectToAction("Index", new { mensaje = "El registro ha sido creado exitosamente" });
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", new { mensaje = ex.Message });
                }
                
            }
        }

        /// <summary>
        /// Elimina documento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _apiConsulta.Eliminar(id, $"{ApiBase}/api/TipoDocumentos/");
                return RedirectToAction("Index", new { mensaje = "El registro ha sido eliminado exitosamente"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index",new {mensaje = ex.Message});
            }
            
        }

        
    }
}
