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
        private Consumos.Global _apiConsulta;
        string ApiBase = string.Empty;
        
        public TipoDocumentosController()
        {
            _apiConsulta = new Consumos.Global();
            ApiBase = System.Configuration.ConfigurationManager.AppSettings.Get("UrlApiBase");
        }
        // GET: TipoDocumentos
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

       

        // POST: TipoDocumentos/Create
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

      

       

        // GET: TipoDocumentos/Delete/5
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
