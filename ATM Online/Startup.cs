using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATM_Online.Startup))]
namespace ATM_Online
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
