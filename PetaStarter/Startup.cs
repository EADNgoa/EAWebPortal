using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PanchayatWebPortal.Startup))]
namespace PanchayatWebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
