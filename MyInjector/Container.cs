using System;
using System.Collections.Generic;
using System.Linq;

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
            Register<TInterface, TImplementation>(Lifecycle.Transient);
        }

        public void Register<TInterface, TImplementation>(Lifecycle lifecycle) where TInterface : class
            where TImplementation : class, TInterface
        {
            var registration = new Registration(typeof(TInterface), typeof(TImplementation),
                lifecycle);
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
            var implementation = GetImplementationInstance(registration);
            return implementation;
        }

        private object GetImplementationInstance(Registration registration)
        {
            switch (registration.Lifecycle)
            {
                case Lifecycle.Singleton:
                    if (registration.ImplementationInstance != null)
                    {
                        return registration.ImplementationInstance;
                    }
                    registration.ImplementationInstance = InitializeImplimentation(registration.ImplementationType);
                    return registration.ImplementationInstance;
                default:
                    var newInstance = InitializeImplimentation(registration.ImplementationType);
                    return newInstance;
            }
        }

        private object InitializeImplimentation(Type type) 
        {
            var constructor = type.GetConstructors().First();
            var parameters = constructor.GetParameters();
            var initializedParameters = parameters
                .Select(parameter => ResolveImplementation(parameter.ParameterType)).ToArray();
            var instance = Activator.CreateInstance(type, initializedParameters);
            return instance;
        }
    }
}
