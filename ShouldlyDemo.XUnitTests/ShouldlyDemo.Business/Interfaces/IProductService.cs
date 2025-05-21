using ShouldlyDemo.Business.Models;

namespace ShouldlyDemo.Business.Interfaces;

public interface IProductService
{
    Product? Get(int id);
    List<Product> GetAll();
    Task Add(Product product);
    void Update(Product product);
    void Delete(int id);
}
