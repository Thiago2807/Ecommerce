using ecommerce_core.Exceptions;

namespace api_ecommerce_auth.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserHandler, UserHandler>();
        services.AddScoped<IAuthHandler, AuthHandler>();
        services.AddScoped<AppDbContext>();

        services.AddExceptionHandler<ExceptionHandlerCustom>();

        //services.AddSingleton<IExceptionHandler, ExceptionHandlerCustom>();

        return services;
    }
}
