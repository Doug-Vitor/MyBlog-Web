public static class ConfigureDataAccess
{
    public static IServiceCollection ConfigureDataAccessServices(this IServiceCollection services) 
        => services.AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUserServices, UserServices>();
}
