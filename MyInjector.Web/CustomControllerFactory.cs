using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyInjector.Web
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly Container _container;

        public CustomControllerFactory(Container container)
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