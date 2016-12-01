using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenTokApp.Startup))]
namespace OpenTokApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
