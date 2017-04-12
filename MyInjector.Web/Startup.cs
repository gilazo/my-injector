using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyInjector.Web.Startup))]
namespace MyInjector.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
