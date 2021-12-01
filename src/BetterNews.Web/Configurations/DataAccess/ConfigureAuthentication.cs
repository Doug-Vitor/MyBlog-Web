using Microsoft.AspNetCore.Authentication.Cookies;

public static class ConfigureAuthentication
{
    public static IServiceCollection ConfigureAuthenticationServices(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.AccessDeniedPath = "/Authentication/AccessDenied";
                options.SlidingExpiration = true;
            });
        services.AddSingleton<HttpContextHelper>();

        return services;
    }
}