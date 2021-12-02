using Microsoft.AspNetCore.Authentication.Cookies;

public static class ConfigureAuthentication
{
    public static IServiceCollection ConfigureAuthenticationServices(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.RequireAuthenticatedSignIn = true;
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
        services.AddSingleton<HttpContextHelper>();

        return services;
    }
}