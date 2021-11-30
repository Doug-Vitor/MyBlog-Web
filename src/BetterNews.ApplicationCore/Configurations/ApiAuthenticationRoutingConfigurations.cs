public class ApiAuthenticationRoutingConfigurations : ApiBaseRoutingConfigurations
{
    public Uri AuthenticationPath { get; set; }

    private Uri GetAuthenticationPath() => new(string.Concat(BasePath, AuthenticationPath));
    public Uri GetGetUserByIdPath(int? userId) => new(string.Concat(GetAuthenticationPath(), $"SignUp/{userId}"));
    public Uri GetSignUpPath() => new(string.Concat(GetAuthenticationPath(), "SignUp/"));
    public Uri GetSignInPath() => new(string.Concat(GetAuthenticationPath(), "SignIn/"));
    public Uri GetUpdateUserPath() => new(string.Concat(GetAuthenticationPath(), "Update/"));
}
