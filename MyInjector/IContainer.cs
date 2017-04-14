using System;

namespace MyInjector
{
    public interface IContainer
    {
        void Register<TInterface, TImplementation>() where TInterface : class
            where TImplementation : class, TInterface;

        void Register<TInterface, TImplementation>(ILifecycleManager lifecycleManager) where TInterface : class
            where TImplementation : class, TInterface;

        T Resolve<T>() where T : class;
        object Resolve(Type type);
    }
}
