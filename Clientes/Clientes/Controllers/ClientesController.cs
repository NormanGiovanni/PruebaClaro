using Consumos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Clientes.Controllers
{
    public class ClientesController : Controller
    {
        private Consumos.Global _apiConsulta;
        string ApiBase = string.Empty;

        public ClientesController()
        {
            _apiConsulta = new Consumos.Global();
            ApiBase = System.Configuration.ConfigurationManager.AppSettings.Get("UrlApiBase");
        }
        public async Task<ActionResult> Index(string mensaje)
        {
            if (!string.IsNullOrEmpty(mensaje))
            {
                if (mensaje.Contains("Error"))
                    ViewBag.Error = mensaje;
                if (mensaje.Contains("registro"))
                    ViewBag.Ok = mensaje;
            }
            var tipodocumentos = await _apiConsulta.Seleccionar<Consumos.Modelos.ModelTipoDocumentos>($"{ApiBase}/api/TipoDocumentos");
            var clientes = await _apiConsulta.Seleccionar<Consumos.Modelos.ModelClientes>($"{ApiBase}/api/Clientes");
            ViewData["TipoDocumento"] = tipodocumentos.Where( b=> b.Activo);
            var model = (from a in clientes
                         join b in tipodocumentos on a.Tipodocumento equals b.Codigo
                         select new ModelClientes
                         {
                             Activo = a.Activo,
                             DescripcionDocumento = b.Descripcion,
                             Codigo = a.Codigo,
                             Identificacion = a.Identificacion,
                             Nombre = a.Nombre,
                             Tipodocumento = a.Tipodocumento,
                             Email = a.Email,
                             Celular = a.Celular,
                              DireccionInstalacion = a.DireccionInstalacion,
                              Direccion = a.Direccion
                         }).ToList();

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Guardar(Consumos.Modelos.ModelClientes model, FormCollection frm)
        {
            try
            {
                var Activo = frm["Activo"];
                if (Activo == "on")
                    model.Activo = true;
                var old = await _apiConsulta.SeleccionarRegistro<Consumos.Modelos.ModelClientes>($"{ApiBase}/api/Clientes/",model.Codigo);
                if (old != null)
                    await _apiConsulta.Actualizar(model, $"{ApiBase}/api/Clientes");

                return RedirectToAction("Index", new { mensaje = "El registro ha sido modficado exitosamente" });
            }
            catch
            {
                try
                {
                    model.Activo = true;
                    await _apiConsulta.Insertar(model, $"{ApiBase}/api/Clientes");
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
                await _apiConsulta.Eliminar(id, $"{ApiBase}/api/Clientes/");
                return RedirectToAction("Index", new { mensaje = "El registro ha sido eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }

        }
        [HttpPost]
        public async Task<ActionResult> CambiarEstado(int id,bool estado)
        {
                await _apiConsulta.Estado(id,estado, $"{ApiBase}/api/Clientes/");
            string mensaje = string.Empty;
            if (estado)
                mensaje = "El registro ha sido activado exitosamente";
            else
                mensaje = "El registro ha sido desctivado exitosamente";

            return Json(new { success = true, message = mensaje });

        }
        



    }
}
