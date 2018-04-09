using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewSite.Startup))]
namespace ReviewSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Add the Role Manager
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        }
    }
}
