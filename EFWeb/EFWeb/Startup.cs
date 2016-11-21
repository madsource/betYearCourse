using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFWeb.Startup))]
namespace EFWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
