using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjMVC5.UI.Sistema.Startup))]
namespace ProjMVC5.UI.Sistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
