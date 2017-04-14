using System;
using System.Linq;

namespace MyInjector
{
    public abstract class LifecycleManager : ILifecycleManager
    {        
        protected object InitializeImplementation(IContainer container, Type type)
        {
            var constructor = type.GetConstructors().First();
            var parameters = constructor.GetParameters();
            var initializedParameters = parameters
                .Select(parameter => container.Resolve(parameter.ParameterType)).ToArray();
            var instance = Activator.CreateInstance(type, initializedParameters);
            return instance;
        }

        abstract public object GetImplementationInstance(IContainer container, Registration registration);
    }
}
