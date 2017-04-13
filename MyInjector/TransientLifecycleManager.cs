namespace MyInjector
{
    public class TransientLifecycleManager : LifecycleManager
    {
        public override object GetImplementationInstance(Container container, Registration registration)
        {
            var newInstance = InitializeImplementation(container, registration.ImplementationType);
            return newInstance;
        }
    }
}
