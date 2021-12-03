using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class HttpContextHelper
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpContextHelper(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

    public async Task SetAuthenticatedUserAsync(string token)
    {
        if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated) return;

        ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new("BearerToken", token));

        ClaimsPrincipal principal = new(identity);
        _contextAccessor.HttpContext.User = new(principal);
        await _contextAccessor.HttpContext.SignInAsync(principal);
    }

    public async Task<string> GetAuthenticatedUserTokenAsync()
    {
        string token = _contextAccessor.HttpContext.User.FindFirst(claim => claim.Type == "BearerToken").Value;

        if (string.IsNullOrWhiteSpace(token))
            await SignOutAuthenticatedUserAsync(); // Ensure user is not authenticated

        return token;
    }

    public async Task SignOutAuthenticatedUserAsync()
    {
        if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}