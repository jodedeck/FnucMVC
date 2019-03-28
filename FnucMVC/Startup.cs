using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FnucMVC.Startup))]
namespace FnucMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
