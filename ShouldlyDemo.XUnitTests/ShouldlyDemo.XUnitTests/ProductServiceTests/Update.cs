using Shouldly;
using ShouldlyDemo.Business.Models;

namespace ShouldlyDemo.XUnitTests.ProductServiceTests;

public class Update : BaseTests
{
    [Fact]
    public void Should_ThrowException_When_ProductNotFound()
    {
        Should.Throw<Exception>(() =>
        {
            ClassUnderTest.Update(new() { Id = 9999 });
        })
            .Message
            .ShouldMatch("Product with ID 9999 not found");
    }

    [Fact]
    public void Should_UpdateTheProduct()
    {
        Product? product = ClassUnderTest.Get(7);

        if (product == null)
            Assert.Fail("Product not found!");

        product.Title = "Updated";
        ClassUnderTest.Update(product);

        Product? secondProduct = ClassUnderTest.Get(7);

        secondProduct.ShouldNotBeNull().Title.ShouldBe("Updated");
    }
}
