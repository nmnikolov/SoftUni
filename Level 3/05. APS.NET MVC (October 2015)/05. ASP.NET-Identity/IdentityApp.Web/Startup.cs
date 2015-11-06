using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityApp.Web.Startup))]
namespace IdentityApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
