using ecommerce_core.Exceptions;

namespace api_ecommerce_pct.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<ExceptionHandlerCustom>();

        //services.AddSingleton<IExceptionHandler, ExceptionHandlerCustom>();

        return services;
    }
}
