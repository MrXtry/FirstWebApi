using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstWebApi.Startup))]
namespace FirstWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
