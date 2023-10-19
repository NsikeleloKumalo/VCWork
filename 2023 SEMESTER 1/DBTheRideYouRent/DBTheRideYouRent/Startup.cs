using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBTheRideYouRent.Startup))]
namespace DBTheRideYouRent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
