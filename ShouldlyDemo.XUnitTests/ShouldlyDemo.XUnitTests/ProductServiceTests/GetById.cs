using Shouldly;
using ShouldlyDemo.Business.Models;

namespace ShouldlyDemo.XUnitTests.ProductServiceTests;

public class GetById : BaseTests
{
    [Fact]
    public void Should_Return_Product()
    {
        // Act
        Product? product = ClassUnderTest.Get(4);

        // Assert
        Assert.NotNull(product);
        Assert.Equal(4, product.Id);
    }

    [Fact]
    public void Should_Return_Product_Shouldly()
    {
        // Act & Assert
        ClassUnderTest.Get(4).ShouldNotBeNull().Id.ShouldBe(4);
    }

    [Fact]
    public void Should_Return_NULL_When_ProductNotFound()
    {
        // Act
        Business.Models.Product? product = ClassUnderTest.Get(100);

        // Assert
        Assert.Null(product);
    }

    [Fact]
    public void Should_Return_NULL_When_ProductNotFound_Shouldly()
    {
        // Act & Assert
        ClassUnderTest.Get(100).ShouldBeNull();
    }
}
