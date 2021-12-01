public interface IAuthenticationRepository
{
    Task<HttpResponseViewModel> GetByIdAsync(int? id, string token);
    Task<HttpLoginResponseViewModel> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpLoginResponseViewModel> SignInAsync(SignInUserModel inputModel);
    Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel, string token);
}