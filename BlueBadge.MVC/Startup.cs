using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueBadge.MVC.Startup))]
namespace BlueBadge.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
