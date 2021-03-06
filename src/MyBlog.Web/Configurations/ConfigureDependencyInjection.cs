public static class ConfigureDependencyInjection
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services,
    ConfigurationManager configurations) => services.ConfigureApiServices(configurations).ConfigureDataAccessServices()
        .ConfigureAuthenticationServices().ConfigureHelpersServices().ConfigureAutoMapperServices();
}
