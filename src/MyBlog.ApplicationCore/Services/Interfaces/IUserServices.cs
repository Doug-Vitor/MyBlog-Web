public interface IUserServices
{
    Task<HttpResponseViewModel> GetByIdAsync(int? id);
    Task<HttpResponseViewModel> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpResponseViewModel> SignInAsync(SignInUserModel inputModel);
    Task SignOutAsync();
    Task<HttpResponseViewModel> GetAuthenticatedUserAsync();
    Task<ErrorViewModel> UpdateAuthenticatedUserAsync(CreateUserInputModel inputModel);
}