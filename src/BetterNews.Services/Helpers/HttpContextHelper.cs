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
        ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new("BearerToken", token));
        await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new(identity));
    }

    public async Task<string> GetAuthenticatedUserToken()
    {
        string token = _contextAccessor.HttpContext.User.FindFirst(claim => claim.Type == "BearerToken").Value;

        if (string.IsNullOrWhiteSpace(token))
            await SignOutAuthenticatedUserAsync(); // Ensure user is not authenticated

        return token;
    }

    public async Task SignOutAuthenticatedUserAsync() 
        => await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}