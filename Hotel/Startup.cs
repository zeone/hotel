using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel.Startup))]
namespace Hotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
