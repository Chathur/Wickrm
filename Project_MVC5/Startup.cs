using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_MVC5.Startup))]
namespace Project_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
