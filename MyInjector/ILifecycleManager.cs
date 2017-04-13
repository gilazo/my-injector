namespace MyInjector
{
    public interface ILifecycleManager
    {
        object GetImplementationInstance(Container container, Registration registration);
    }
}
