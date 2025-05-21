using ShouldlyDemo.Business;

namespace ShouldlyDemo.XUnitTests;

public class BaseTests
{
    public readonly ProductService ClassUnderTest;

    public BaseTests()
    {
        ClassUnderTest = new();
    }
}
