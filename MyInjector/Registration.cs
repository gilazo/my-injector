using System;

namespace MyInjector
{
    public sealed class Registration
    {
        public Type InterfaceType { get; private set; }
        public Type ImplementationType { get; private set; }
        public ILifecycleManager LifecycleManager { get; private set; }
        public object ImplementationInstance { get; set; }

        public Registration(Type interfaceType, Type implementationType, ILifecycleManager lifecycleManager)
        {
            InterfaceType = interfaceType;
            ImplementationType = implementationType;
            LifecycleManager = lifecycleManager;
        }
    }
}
