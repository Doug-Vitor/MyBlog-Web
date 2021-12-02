public static class ConfigureAutoMapper
{
    public static IServiceCollection ConfigureAutoMapperServices(this IServiceCollection services)
        => services.AddAutoMapper(typeof(Program).Assembly);
}
