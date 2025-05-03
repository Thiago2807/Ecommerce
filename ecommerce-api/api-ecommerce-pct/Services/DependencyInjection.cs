using api_ecommerce_pct.Data;
using api_ecommerce_pct.Handler;
using api_ecommerce_pct.Interfaces.Handler;
using api_ecommerce_pct.Interfaces.Repository;
using api_ecommerce_pct.Repository;
using ecommerce_core.Exceptions;

namespace api_ecommerce_pct.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryHandler, CategoryHandler>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductHandler, ProductHandler>();

        services.AddScoped<AppDbContext>();
        services.AddExceptionHandler<ExceptionHandlerCustom>();

        //services.AddSingleton<IExceptionHandler, ExceptionHandlerCustom>();

        return services;
    }
}
