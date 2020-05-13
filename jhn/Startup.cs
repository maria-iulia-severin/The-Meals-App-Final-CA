using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jhn.Startup))]
namespace jhn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
