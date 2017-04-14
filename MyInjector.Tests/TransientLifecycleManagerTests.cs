using Xunit;

namespace MyInjector.Tests
{
    public class TransientLifecycleManagerTests
    {
        [Fact]
        public void ShouldReturnANewImplementationInstanceWithEachResolutionRequest()
        {
            var container = new Container();         
            var lifecycleManager = new TransientLifecycleManager();
            var registration = new Registration(typeof (IAmATestInterface), typeof (ImplementationTest), lifecycleManager);
            var firstInstanceClass = lifecycleManager.GetImplementationInstance(container, registration);
            var secondInstanceClass = lifecycleManager.GetImplementationInstance(container, registration);
            Assert.NotSame(firstInstanceClass, secondInstanceClass);
        }
    }
}
