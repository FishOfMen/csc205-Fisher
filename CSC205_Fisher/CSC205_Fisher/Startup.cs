using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC205_Fisher.Startup))]
namespace CSC205_Fisher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
