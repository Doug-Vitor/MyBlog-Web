public interface IUserServices
{
    Task<HttpResponseViewModel<UserViewModel>> GetByIdAsync(int? id);
    Task<HttpResponseViewModel<UserViewModel>> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpResponseViewModel<UserViewModel>> SignInAsync(SignInUserModel inputModel);
    Task SignOutAsync();
    Task<HttpResponseViewModel<UserViewModel>> GetAuthenticatedUserAsync();
    Task<ErrorViewModel> UpdateAuthenticatedUserAsync(CreateUserInputModel inputModel);
}