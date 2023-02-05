using Entities.Concrete;

namespace Business.Abstract;
public interface IProductService
{
    List<Product> GetAll();
    List<Product> GetByCategoryId(int categoryId);
    List<Product> GetProductsByProductName(string productName);
    Product Get(int productId);
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
}