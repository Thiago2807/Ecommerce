using ecommerce_core.Dtos.loj;
using ecommerce_core.Dtos.pct;
using ecommerce_core.Models;

namespace ecommerce_core.Utils;

public static class ValidationsUtils
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        /// IUA
        services.AddValidatorsFromAssemblyContaining<AuthInsertValidation>();
        services.AddValidatorsFromAssemblyContaining<PaginationModelValidation>();
        services.AddValidatorsFromAssemblyContaining<RecoverPasswordValidation>();

        /// LOJ
        services.AddValidatorsFromAssemblyContaining<StoreRegisterValid>();
        services.AddValidatorsFromAssemblyContaining<StoreRegisterContactsValid>();
        services.AddValidatorsFromAssemblyContaining<StoreUpdateValid>();
        services.AddValidatorsFromAssemblyContaining<StoreContactUpdateValid>();

        /// PCT
        services.AddValidatorsFromAssemblyContaining<CategoryValid>();
        services.AddValidatorsFromAssemblyContaining<ProductValid>();

        // Adicionado no pipe da requisição para realizar as validações de maneira automatica
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
            
        });

        return services;
    }
}
