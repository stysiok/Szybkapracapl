using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Szybkapracapl.Startup))]
namespace Szybkapracapl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
