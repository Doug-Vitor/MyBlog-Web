public static class ConfigureApi
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services, ConfigurationManager configurations)
        => services.Configure<ApiAuthenticationRoutingConfigurations>(configurations.GetSection(nameof(ApiAuthenticationRoutingConfigurations)));
}
