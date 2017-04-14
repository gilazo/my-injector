using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyInjector.Web.Controllers;
using MyInjector.Web.Services;

namespace MyInjector.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            container.Register<ILookupUsers, UserRetriever>();
            container.Register<TestController, TestController>();

            var controllerFactory = new CustomControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
