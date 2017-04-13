namespace MyInjector
{
    public class SingletonLifecycleManager : LifecycleManager
    {
        public override object GetImplementationInstance(Container container, Registration registration)
        {
            if (registration.ImplementationType != null)
            {
                return registration.ImplementationInstance;
            }
            registration.ImplementationInstance = InitializeImplementation(container, registration.ImplementationType);
            return registration.ImplementationInstance;
        }
    }
}
