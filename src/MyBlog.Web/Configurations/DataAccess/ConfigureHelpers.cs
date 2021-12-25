public static class ConfigureHelpers
{
    public static IServiceCollection ConfigureHelpersServices(this IServiceCollection services) => services.AddScoped<IPostHelper, PostHelper>();
}
