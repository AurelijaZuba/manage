using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(manage.Startup))]
namespace manage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
