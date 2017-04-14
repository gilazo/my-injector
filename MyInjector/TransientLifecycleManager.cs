namespace MyInjector
{
    public class TransientLifecycleManager : LifecycleManager
    {
        public override object GetImplementationInstance(IContainer container, Registration registration)
        {
            var newInstance = InitializeImplementation(container, registration.ImplementationType);
            return newInstance;
        }
    }
}
