using ShouldlyDemo.Business.Models;

namespace ShouldlyDemo.XUnitTests.ProductServiceTests;

public class Delete : BaseTests
{
    [Fact]
    public void Should_DeleteProduct()
    {
        Product productToDelete = ClassUnderTest.Get(7);

        
    }
}
