using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetResort.WebUI.Startup))]
namespace PetResort.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
