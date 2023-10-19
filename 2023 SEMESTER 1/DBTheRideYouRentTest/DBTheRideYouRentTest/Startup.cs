using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBTheRideYouRentTest.Startup))]
namespace DBTheRideYouRentTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
