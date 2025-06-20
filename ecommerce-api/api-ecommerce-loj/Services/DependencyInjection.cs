using api_ecommerce_loj.Data;
using api_ecommerce_loj.Handler;
using api_ecommerce_loj.Interfaces;
using api_ecommerce_loj.Repository;
using ecommerce_core.Exceptions;

namespace api_ecommerce_loj.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
        services.AddScoped<IStoreContactRepository, StoreContactRepository>();
        services.AddScoped<IStoreHandler, StoreHandler>();

        services.AddExceptionHandler<ExceptionHandlerCustom>();

        services.AddSingleton<AppDbContext>();

        return services;
    }
}
