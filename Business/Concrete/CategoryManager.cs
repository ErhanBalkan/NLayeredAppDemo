using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete;
public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();        
    }
}