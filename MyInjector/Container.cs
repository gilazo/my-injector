using System;
using System.Collections.Generic;

namespace MyInjector
{
    public sealed class Container
    {
        private readonly IDictionary<Type, Registration> _registrations;

        public Container()
        {
            _registrations = new Dictionary<Type, Registration>();
        }

        public void Register<TInterface, TImplementation>() where TInterface : class 
            where TImplementation : class, TInterface
        {
            Register<TInterface, TImplementation>(new TransientLifecycleManager());
        }

        public void Register<TInterface, TImplementation>(ILifecycleManager lifecycleManager) where TInterface : class
            where TImplementation : class, TInterface
        {
            var registration = new Registration(typeof(TInterface), typeof(TImplementation),
                lifecycleManager);
            _registrations.Add(typeof(TInterface), registration);
        }

        public T Resolve<T>() where T : class
        {
            var instance = (T)ResolveImplementation(typeof (T));
            return instance;
        }

        public object Resolve(Type type)
        {
            var instance = ResolveImplementation(type);
            return instance;
        }

        private object ResolveImplementation(Type type)
        {            
            if (!_registrations.ContainsKey(type))
            {
                throw new RegisteredTypeNotFoundException($"Cannot find a registration for type {type}");
            }
            var registration = _registrations[type];
            var implementation = registration.LifecycleManager.GetImplementationInstance(this, registration);
            return implementation;
        }
    }
}
