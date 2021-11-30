public interface IAuthenticationRepository
{
    Task<HttpResponseViewModel<UserViewModel>> GetByIdAsync(int? id);
    Task<HttpResponseViewModel<LoginResultViewModel>> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpResponseViewModel<LoginResultViewModel>> SignInAsync(SignInUserModel inputModel);
    Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel);
}