using Business.Abstract;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete;
public class ProductManager : IProductService
{
    // Dependency Injection
    private IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void Add(Product product)
    {
        ValidationTool.Validate(new ProductValidator(), product);
        _productDal.Add(product);
    }

    public void Delete(Product product)
    {
        _productDal.Delete(product);
    }

    public Product Get(int productId)
    {
        return _productDal.Get(p => p.ProductId == productId);
    }

    public List<Product> GetAll(){
        return _productDal.GetAll();
    }

    public List<Product> GetByCategoryId(int categoryId)
    {
        return _productDal.GetAll(p => p.CategoryId == categoryId);
    }

    public List<Product> GetProductsByProductName(string productName)
    {
        return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
    }

    public void Update(Product product)
    {
        ValidationTool.Validate(new ProductValidator(), product);
        _productDal.Update(product);
    }
}