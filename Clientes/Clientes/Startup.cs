using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clientes.Startup))]
namespace Clientes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
