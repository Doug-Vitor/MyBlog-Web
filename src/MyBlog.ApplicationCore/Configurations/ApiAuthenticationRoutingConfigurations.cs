public class ApiAuthenticationRoutingConfigurations
{
    public Uri BasePath { get; set; }
    public Uri AuthenticationPath { get; set; }
    private Uri AuthenticationBasePath => new(string.Concat(BasePath, AuthenticationPath));

    public Uri SignUpPath => new(string.Concat(AuthenticationBasePath, "SignUp/"));
    public Uri SignInPath => new(string.Concat(AuthenticationBasePath, "SignIn/"));
    public Uri SignOutPath => new(string.Concat(AuthenticationBasePath, "SignOut/"));
    public Uri AuthenticatedUserPath => new(string.Concat(AuthenticationBasePath, "AuthenticatedUser/"));

    public Uri RetrieveGetUserByIdPath(int? userId) => new(string.Concat(AuthenticationBasePath, $"SignUp/{userId}"));
    public Uri RetrieveUpdateUserPath() => new(string.Concat(AuthenticatedUserPath, "Update/"));
}