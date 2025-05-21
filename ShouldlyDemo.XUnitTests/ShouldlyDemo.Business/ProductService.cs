using ShouldlyDemo.Business.Enums;
using ShouldlyDemo.Business.Interfaces;
using ShouldlyDemo.Business.Models;

namespace ShouldlyDemo.Business;

public class ProductService : IProductService
{
    private static readonly List<Product> Products =
    [
        new() { Id = 1, Title = "7Up", Status = Status.Ordered, Stock = 10, Available = true },
        new() { Id = 2, Title = "Chips", Status = Status.Ordered, Stock = 0, Available = true },
        new() { Id = 3, Title = "Sugar", Status = Status.Delivered, Stock = 67, Available = true },
        new() { Id = 4, Title = "Meatballs", Status = Status.Delivered, Stock = 5, Available = true },
        new() { Id = 5, Title = "Milk", Status = Status.Delivered, Stock = 7, Available = true },
        new() { Id = 6, Title = "Chewinggum", Status = Status.Delivered, Stock = 0, Available = false },
        new() { Id = 7, Title = "Toiletpaper", Status = Status.Delivered, Stock = 1, Available = true },
        new() { Id = 8, Title = "Tea", Status = Status.Delivered, Stock = 5, Available = true },
        new() { Id = 9, Title = "Coffee", Status = Status.Delivered, Stock = 85, Available = true },
        new() { Id = 10, Title = "Biscuits", Status = Status.Delivered, Stock = 12, Available = true },
        new() { Id = 11, Title = "Chocolate", Status = Status.Delivered, Stock = 89, Available = true },
        new() { Id = 12, Title = "Bread", Status = Status.Delivered, Stock = 167, Available = true },
    ];

    public async Task Add(Product product)
    {
        if(string.IsNullOrEmpty(product.Title))
            throw new ArgumentNullException(nameof(product.Title));

        await Task.Run(() =>
        {
            product.Id = Products.Max(x => x.Id) + 1;
            Products.Add(product);
        });
    }

    public void Delete(int id)
    {
        Product? productToDelete = Products.SingleOrDefault(x => x.Id == id)
            ?? throw new Exception($"Product with ID {id} not found.");

        Products.Remove(productToDelete);
    }

    public Product? Get(int id) => Products.SingleOrDefault(x => x.Id == id);

    public List<Product> GetAll() => Products;

    public void Update(Product product)
    {
        Product? productToUpdate = Get(product.Id)
            ?? throw new Exception($"Product with ID {product.Id} not found");

        productToUpdate.Status= product.Status;
        productToUpdate.Stock = product.Stock;
        productToUpdate.Available = product.Available;
        productToUpdate.Title = product.Title;
    }
}
