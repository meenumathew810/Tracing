using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tracing.Startup))]
namespace Tracing
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
