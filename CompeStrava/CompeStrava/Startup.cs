using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompeStrava.Startup))]
namespace CompeStrava
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
