using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quali_T_Repair_and_Services.Startup))]
namespace Quali_T_Repair_and_Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
