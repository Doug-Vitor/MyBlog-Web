public interface IAuthenticationServices
{
    Task<HttpResponseViewModel> GetByIdAsync(int? id);
    Task<HttpResponseViewModel> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpResponseViewModel> SignInAsync(SignInUserModel inputModel);
    Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel);
}