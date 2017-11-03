using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassworkPractic.Startup))]
namespace ClassworkPractic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
