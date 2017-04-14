using Xunit;

namespace MyInjector.Tests
{
    public class SingletonLifecycleManagerTests
    {
        [Fact]
        public void ShouldReturnTheSameImplementationInstanceWithEachResolutionRequest()
        {
            var container = new Container();
            var lifecycleManager = new SingletonLifecycleManager();
            var registration = new Registration(typeof(IAmATestInterface), typeof(ImplementationTest), lifecycleManager);
            var firstInstanceReference = lifecycleManager.GetImplementationInstance(container, registration);
            var secondInstanceReference = lifecycleManager.GetImplementationInstance(container, registration);
            Assert.Same(firstInstanceReference, secondInstanceReference);
        }
    }
}
