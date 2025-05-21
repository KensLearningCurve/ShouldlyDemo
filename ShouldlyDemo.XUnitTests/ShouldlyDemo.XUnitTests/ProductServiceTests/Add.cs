using Shouldly;
using ShouldlyDemo.Business.Models;

namespace ShouldlyDemo.XUnitTests.ProductServiceTests;

public class Add : BaseTests
{
    [Fact]
    public async Task Should_ThrowArgumentNullException_When_TitleIsInvalid()
    {
        Product product = new()
        {
            Available = true,
            Status = Business.Enums.Status.Delivered,
            Stock = 46
        };

        ArgumentNullException exception = await Should.ThrowAsync<ArgumentNullException>(() => ClassUnderTest.Add(product));
        exception.Message.ShouldBe("Value cannot be null. (Parameter 'Title')");
    }

    [Fact]
    public async Task Should_AddProduct()
    {
        Product product = new()
        {
            Title = "Pancakes",
            Available = true,
            Status = Business.Enums.Status.Delivered,
            Stock = 46
        };

        await ClassUnderTest.Add(product);

        List<Product> products = ClassUnderTest.GetAll();

        products.First(x => x.Title ==  product.Title).ShouldSatisfyAllConditions(
            p => p.Stock.ShouldBe(product.Stock),
            p => p.Available.ShouldBeTrue(),
            p => p.Status.ShouldBe(product.Status));
    }
}
