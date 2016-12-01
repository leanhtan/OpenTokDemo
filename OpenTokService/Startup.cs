using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OpenTokService.Startup))]

namespace OpenTokService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
