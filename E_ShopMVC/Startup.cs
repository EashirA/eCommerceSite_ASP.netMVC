using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_ShopMVC.Startup))]
namespace E_ShopMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
