public interface IUserRepository
{
    Task<HttpResponseViewModel> GetByIdAsync(int? id, string token);
    Task<HttpLoginResponseViewModel> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpLoginResponseViewModel> SignInAsync(SignInUserModel inputModel);
    Task SignOutAsync();
    Task<HttpResponseViewModel> GetAuthenticatedUserAsync(string token);
    Task<ErrorViewModel> UpdateAuthenticatedUserAsync(CreateUserInputModel inputModel, string token);
}