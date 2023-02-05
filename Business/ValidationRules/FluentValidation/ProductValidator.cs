using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;
public class ProductValidator : AbstractValidator<Product>
{
    // Fluent validation'da kurallar Constructor içerisinde yazılır.
    public ProductValidator(){
        RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.CategoryId).NotEmpty();
        RuleFor(p => p.UnitPrice).NotEmpty();
        RuleFor(p => p.QuantityPerUnit).NotEmpty();
        RuleFor(p => p.UnitsInStock).NotEmpty();

        RuleFor(p => p.UnitPrice).GreaterThan(0);
        RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
        RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);
        // CategoryId 2 ise fiyati 10'dan büyük olmalı.
        
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adı A ile başlamalıdır."); 
        // Kendi özel kuralımızı Must ile yazdık.
        // WithMessage ile kendi mesajımızı belirtebiliriz belirtmezsek 
        // sistemimiz hangi dildeyse o dilde hata mesajı kendisi üretir.


    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
        // A ile başlıyorsa true dönecek.
    }
}