using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlgebraSchoolApp.Startup))]
namespace AlgebraSchoolApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
