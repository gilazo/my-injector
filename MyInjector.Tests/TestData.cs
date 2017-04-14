namespace MyInjector.Tests
{
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
