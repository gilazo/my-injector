using Xunit;

namespace MyInjector.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void ShouldRegisterImplementationToInterface()
        {
            var container = new Container();
            container.Register<IAmATestInterface, ImplementationTest>();
            var resolvedClass = container.Resolve<IAmATestInterface>();
            Assert.IsType<ImplementationTest>(resolvedClass);
        }

        [Fact]
        public void ShouldRegisterImplementationToInterfaceWithDefaultLifecycleTransient()
        {
            var container = new Container();
            container.Register<IAmATestInterface, ImplementationTest>();
            var firstInstanceClass = container.Resolve<IAmATestInterface>();
            var secondInstanceClass = container.Resolve<IAmATestInterface>();
            Assert.NotSame(firstInstanceClass, secondInstanceClass);
        }

        [Fact]
        public void ShouldRegisterImplementationToInterfaceWithSpecifiedLifecycleTransient()
        {
            var container = new Container();
            container.Register<IAmATestInterface, ImplementationTest>(new TransientLifecycleManager());
            var firstInstanceClass = container.Resolve<IAmATestInterface>();
            var secondInstanceClass = container.Resolve<IAmATestInterface>();
            Assert.NotSame(firstInstanceClass, secondInstanceClass);
        }

        [Fact]
        public void ShouldRegisterImplementationToInterfaceWithSpecifiedLifecycleSingelton()
        {
            var container = new Container();
            container.Register<IAmATestInterface, ImplementationTest>(new SingletonLifecycleManager());
            var firstInstanceReference = container.Resolve<IAmATestInterface>();
            var secondInstanceReference = container.Resolve<IAmATestInterface>();
            Assert.Same(firstInstanceReference, secondInstanceReference);
        }

        [Fact]
        public void ShouldThrowExceptionWhenAttemptingToResolveAnUnregsiteredType()
        {
            var container = new Container();
            var exception = Assert.Throws<RegisteredTypeNotFoundException>(() => container.Resolve<IAmATestInterface>());
            Assert.Equal($"Cannot find a registration for type {typeof(IAmATestInterface)}", exception.Message);
        }

        [Fact]
        public void ShouldRegisterAnImplementationWithParametersToAnInterface()
        {
            var container = new Container();
            container.Register<IAmATestInterface, ImplementationTest>();
            container.Register<IAmAnothertestInterface, ImplementationOfAnotherTest>();
            container.Register<IAmAParameterTestInterface, ParameterImplementationTest>();
            var instance = container.Resolve<IAmAParameterTestInterface>();
            Assert.IsType<ParameterImplementationTest>(instance);
        }

        [Fact]
        public void ShouldThrowRegisteredTypeNotFoundExceptionWhenAttemptingToResolveAnUnregisterdParameterType()
        {
            var container = new Container();
            container.Register<IAmAParameterTestInterface, ParameterImplementationTest>();
            var exception =
                Assert.Throws<RegisteredTypeNotFoundException>(() => container.Resolve<IAmAParameterTestInterface>());
            Assert.Equal($"Cannot find a registration for type {typeof(IAmATestInterface)}", exception.Message);
        }
    }

    public interface IAmATestInterface { }
    public class ImplementationTest : IAmATestInterface { }
    public interface IAmAnothertestInterface { }
    public class ImplementationOfAnotherTest : IAmAnothertestInterface { }
    public interface IAmAParameterTestInterface { }
    public class ParameterImplementationTest : IAmAParameterTestInterface
    {
        public ParameterImplementationTest(IAmATestInterface implementationTest,
            IAmAnothertestInterface implementationOfAnotherTest)
        {
        }
    }
}
