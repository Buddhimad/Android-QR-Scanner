using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ijse.pos.Presentation.Web.Startup))]
namespace ijse.pos.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
