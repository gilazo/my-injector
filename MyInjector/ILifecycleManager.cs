namespace MyInjector
{
    public interface ILifecycleManager
    {
        object GetImplementationInstance(IContainer container, Registration registration);
    }
}
