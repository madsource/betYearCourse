using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EfDemo.Startup))]
namespace EfDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
