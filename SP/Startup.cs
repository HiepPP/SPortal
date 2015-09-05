using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SetPortal.Startup))]
namespace SetPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
