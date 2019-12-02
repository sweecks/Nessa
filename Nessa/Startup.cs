using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nessa.Startup))]
namespace Nessa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
