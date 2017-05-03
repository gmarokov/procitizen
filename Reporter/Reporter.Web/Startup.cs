using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reporter.Web.Startup))]
namespace Reporter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
