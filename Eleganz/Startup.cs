using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EleganzApi.Startup))]

namespace EleganzApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}
