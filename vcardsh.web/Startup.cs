using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vcardsh.web.Startup))]
namespace vcardsh.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
