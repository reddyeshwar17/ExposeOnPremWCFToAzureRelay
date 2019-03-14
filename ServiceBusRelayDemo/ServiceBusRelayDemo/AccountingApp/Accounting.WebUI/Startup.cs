using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Accounting.WebUI.Startup))]
namespace Accounting.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
