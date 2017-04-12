using System;

namespace MyInjector
{
    public sealed class Registration
    {
        public Type InterfaceType { get; private set; }
        public Type ImplementationType { get; private set; }
        public Lifecycle Lifecycle { get; private set; }
        public object ImplementationInstance { get; set; }

        public Registration(Type interfaceType, Type implementationType, Lifecycle lifecycle)
        {
            InterfaceType = interfaceType;
            ImplementationType = implementationType;
            Lifecycle = lifecycle;
        }
    }
}
