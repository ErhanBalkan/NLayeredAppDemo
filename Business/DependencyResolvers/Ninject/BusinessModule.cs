using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Business.DependencyResolvers.Ninject;
public class BusinessModule : NinjectModule
{
    public override void Load()
    {
        // Biri senden IProductService isterse ona ProductManager instance'ı döndür.
        // Eğer her yere aynı instance verilsin istiyorsan yani uygulamada bir instance oluşsun her yere o verilsin istiyorsan
        // InSıngletonScope()
        // Bunlar sadece operasyon olduğu için yani bir statik değer tutmadığı için tek instance kullanabilirsin.
        // örneğin eticaret sitesinde sepet düşünürsen burda tek instance kullanamazsın herkese ayrı olmalı çünkü biri sepete bişey
        // eklediğinde herkesin sepetine eklenirdi.
        Bind<IProductService>().To<ProductManager>().InSingletonScope();
        Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
        Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
        Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
    }
}