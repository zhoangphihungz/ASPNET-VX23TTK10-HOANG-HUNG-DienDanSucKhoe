using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthWebApp_Authenticated.Startup))]
namespace HealthWebApp_Authenticated
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
