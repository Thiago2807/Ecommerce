namespace api_ecommerce_auth.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserHandler, UserHandler>();
        services.AddScoped<AppDbContext>();

        return services;
    }
}
