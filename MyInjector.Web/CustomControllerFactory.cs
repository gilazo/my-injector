using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyInjector.Web
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public CustomControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            return (IController) _container.Resolve(controllerType);
        }
    }
}