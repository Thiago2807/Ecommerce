using ecommerce_core.Models;

namespace ecommerce_core.Utils;

public static class ValidationsUtils
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AuthInsertValidation>();
        services.AddValidatorsFromAssemblyContaining<PaginationModelValidation>();
        services.AddValidatorsFromAssemblyContaining<RecoverPasswordValidation>();

        // Adicionado no pipe da requisição para realizar as validações de maneira automatica
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
            
        });

        return services;
    }
}
