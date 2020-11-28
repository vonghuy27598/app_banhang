using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DA_Web.Startup))]
namespace DA_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
