using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(damacana.Startup))]
namespace damacana
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
