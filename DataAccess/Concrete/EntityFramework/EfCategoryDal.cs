using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

public class EfCategoryDal : EfEntityRepositoryBase<Category,NorthwindContext> , ICategoryDal
{
    
}