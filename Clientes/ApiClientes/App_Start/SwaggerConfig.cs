using System.Web.Http;
using WebActivatorEx;
using ApiClientes;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ApiClientes
{
    public class SwaggerConfig
    {
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\Document\ApiClientes.XML",
                System.AppDomain.CurrentDomain.BaseDirectory);
        }
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

           

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Api Clientes");
                       c.IncludeXmlComments(GetXmlCommentsPath());

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Api clientes");
                    });
        }
    }
}
