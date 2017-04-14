namespace MyInjector
{
    public class SingletonLifecycleManager : LifecycleManager
    {
        public override object GetImplementationInstance(IContainer container, Registration registration)
        {
            if (registration.ImplementationInstance != null)
            {
                return registration.ImplementationInstance;
            }
            registration.ImplementationInstance = InitializeImplementation(container, registration.ImplementationType);
            return registration.ImplementationInstance;
        }
    }
}
