using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectsTracker.Startup))]
namespace ProjectsTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
