using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolThreeTireDemo.Startup))]
namespace SchoolThreeTireDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
