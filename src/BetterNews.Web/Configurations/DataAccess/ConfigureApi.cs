public static class ConfigureApi
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services, ConfigurationManager configurations)
        => services.Configure<ApiBaseRoutingConfigurations>(configurations.GetSection(nameof(ApiBaseRoutingConfigurations)))
        .Configure<ApiAuthenticationRoutingConfigurations>(configurations.GetSection(nameof(ApiAuthenticationRoutingConfigurations)));
}
