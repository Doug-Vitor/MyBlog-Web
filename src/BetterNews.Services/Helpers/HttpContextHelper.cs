using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class HttpContextHelper
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpContextHelper(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

    public void SetAuthenticatedUser(string token)
    {
        ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new()"BearerToken", token));
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

        _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    public string GetAuthenticatedUserToken()
    {
        string token = _contextAccessor.HttpContext.User.FindFirst(claim => claim.Type == "BearerToken").Value;

        if (string.IsNullOrWhiteSpace(token))
            LogoutAuthenticatedUser(); // Ensure user is not authenticated

        return token;
    }

    public async Task LogoutAuthenticatedUser() 
        => await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}