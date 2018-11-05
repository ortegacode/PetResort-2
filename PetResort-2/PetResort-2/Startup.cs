using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetResort_2.Startup))]
namespace PetResort_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
