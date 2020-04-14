using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartTimeV1.Startup))]
namespace PartTimeV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
