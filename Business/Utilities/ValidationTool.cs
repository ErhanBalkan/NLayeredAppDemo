using FluentValidation;

namespace Business.Utilities;
public static class ValidationTool
{
    // IValidator base interface olduğu için 
    // parametre abstractValidatorden implemente edilen
    // her validator sınıfını kapsar.
    // örn: ProductValidator, CustomerValidator vs.
    public static void Validate(IValidator validator, object entity){
        var result = validator.Validate((IValidationContext)entity);
        if (result.Errors.Count > 0)
            throw new ValidationException(result.Errors);
    }
}