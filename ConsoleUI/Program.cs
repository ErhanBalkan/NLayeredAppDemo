using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Entities.Concrete;

// ---------------------------- Ninject IoC Container ----------------------------
ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
IProductService _productService = InstanceFactory.GetInstance<IProductService>();
// ---------------------------- Ninject IoC Container ----------------------------

SelectedOperation();

void SelectedOperation(){
    System.Console.WriteLine("--------------------");
    System.Console.WriteLine("1- Kategorileri listele");
    System.Console.WriteLine("2- Ürünleri listele");
    System.Console.WriteLine("3- Ürünleri kategori ID'ye göre listele");
    System.Console.WriteLine("4- Ürünleri ürün adına göre listele");
    System.Console.WriteLine("5- Ürün ekle");
    System.Console.WriteLine("6- Ürün güncelle");
    System.Console.WriteLine("7- Ürün sil");
    System.Console.WriteLine("--------------------");
    byte selectIndex = Convert.ToByte(System.Console.ReadLine());
    if(selectIndex == 1)
        LoadCategories();
    else if(selectIndex == 2)
        LoadProducts();
    else if(selectIndex == 3)
        LoadProductsByCategoryId();
    else if(selectIndex == 4)
        LoadProductsByProductName();
    else if(selectIndex == 5)
        AddProduct();
    else if(selectIndex == 6)
        UpdateProduct();
    else if(selectIndex == 7)
        DeleteProduct();
    else
        System.Console.WriteLine("Hatalı seçim!");
        SelectedOperation();
}

void LoadCategories(){
    List<Category> categoryList = _categoryService.GetAll();
    categoryList.ForEach(c => {
        System.Console.WriteLine($"{c.CategoryId} | {c.CategoryName}");
    });
    SelectedOperation();
}
void LoadProducts(){
    List<Product> productList = _productService.GetAll();
    productList.ForEach(p =>
    {
        System.Console.WriteLine($"{p.ProductId} | {p.ProductName}");
    });
    SelectedOperation();
}
void LoadProductsByCategoryId(){
    System.Console.Write("Kategori ID giriniz: ");
    byte categoryId = Convert.ToByte(System.Console.ReadLine());
    List<Product> productList = _productService.GetByCategoryId(categoryId);
    productList.ForEach(p => {
        System.Console.WriteLine($"Category ID: {p.CategoryId} | Product ID: {p.ProductId} | Product Name: {p.ProductName}");
    });
}
void LoadProductsByProductName(){
    System.Console.Write("Product name giriniz: ");
    string productName = System.Console.ReadLine();
    List<Product> productList = _productService.GetProductsByProductName(productName);
    if (productName.Length == 0)
        LoadProducts();
    else{
    productList.ForEach(p => {
        System.Console.WriteLine($"Product ID: {p.ProductId} | Product Name: {p.ProductName}");
    });
    }
}
void AddProduct(){
    System.Console.Write("Kategori ID giriniz: ");
    int categoryId = int.Parse(Console.ReadLine());
    System.Console.WriteLine();
    System.Console.Write("Ürün adı giriniz: ");
    string productName = Console.ReadLine();
    System.Console.WriteLine();
    System.Console.Write("Birim başı miktar giriniz: ");
    string quantityPerUnit = Console.ReadLine();
    System.Console.WriteLine();
    System.Console.Write("Ürün fiyatı giriniz: ");
    decimal unitPrice = Convert.ToDecimal(Console.ReadLine());
    System.Console.WriteLine();
    System.Console.Write("Stok adedi giriniz: ");
    Int16 unitsInStock = Int16.Parse(Console.ReadLine());
    System.Console.WriteLine();
    try{
    _productService.Add(new Product{
        CategoryId = categoryId,
        ProductName = productName,
        QuantityPerUnit = quantityPerUnit,
        UnitPrice = unitPrice,
        UnitsInStock = unitsInStock
    });
    System.Console.WriteLine("Ürün kaydedildi.");
    SelectedOperation();
    }catch(Exception ex){
        System.Console.WriteLine(ex.Message);
    }
}
void UpdateProduct(){
    System.Console.Write("Güncellemek istediğiniz ürünün ID numarasını giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());
    System.Console.Write("Kategori ID giriniz: ");
    int categoryId = int.Parse(Console.ReadLine());
    System.Console.WriteLine();
    System.Console.Write("Ürün adı giriniz: ");
    string productName = Console.ReadLine();
    System.Console.WriteLine();
    System.Console.Write("Birim başı miktar giriniz: ");
    string quantityPerUnit = Console.ReadLine();
    System.Console.WriteLine();
    System.Console.Write("Ürün fiyatı giriniz: ");
    decimal unitPrice = Convert.ToDecimal(Console.ReadLine());
    System.Console.WriteLine();
    System.Console.Write("Stok adedi giriniz: ");
    Int16 unitsInStock = Int16.Parse(Console.ReadLine());
    System.Console.WriteLine();
    Product updatedProduct = _productService.Get(id);
    updatedProduct.CategoryId = categoryId;
    updatedProduct.ProductName = productName;
    updatedProduct.QuantityPerUnit = quantityPerUnit;
    updatedProduct.UnitPrice = unitPrice;
    updatedProduct.UnitsInStock = unitsInStock;
    _productService.Update(updatedProduct);
    System.Console.WriteLine("Ürün güncellendi.");
    SelectedOperation();
}
void DeleteProduct(){
    System.Console.Write("Ürün ID giriniz: ");
    int productId = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine();
    Product deletedProduct = _productService.Get(productId);
    _productService.Delete(deletedProduct);
    System.Console.WriteLine("Ürün silindi.");
    SelectedOperation();
}
