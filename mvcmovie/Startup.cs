using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcmovie.Startup))]
namespace mvcmovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
