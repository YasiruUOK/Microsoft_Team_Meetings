using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Microsoft_team.Startup))]

namespace Microsoft_team
{
    public partial class Startup
    {
        public void Configuration(Owin.IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}