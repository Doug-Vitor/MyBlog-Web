public class ApiAuthenticationRoutingConfigurations
{
    public static Uri BasePath { get; set; }
    public static Uri AuthenticationPath { get; set; }

    public Uri SignUpPath { get; } = new(string.Concat(AuthenticationPath, "SignUp/"));
    public Uri SignInPath { get; } = new(string.Concat(AuthenticationPath, "SignIn/"));
    public Uri SignOutPath { get; } = new(string.Concat(AuthenticationPath, "SignOut/"));
    public Uri AuthenticatedUserPath { get; } = new(string.Concat(AuthenticationPath, "AuthenticatedUser/"));

    public Uri RetrieveGetUserByIdPath(int? userId) => new(string.Concat(AuthenticationPath, $"SignUp/{userId}"));
    public Uri RetrieveUpdateUserPath() => new(string.Concat(AuthenticationPath, AuthenticatedUserPath, "Update/"));
}
