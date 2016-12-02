using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontEndWebSite.Startup))]
namespace FrontEndWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
