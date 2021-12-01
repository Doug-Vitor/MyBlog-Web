public interface IUserRepository
{
    Task<HttpResponseViewModel> GetByIdAsync(int? id, string token);
    Task<HttpLoginResponseViewModel> SignUpAsync(CreateUserInputModel inputModel);
    Task<HttpLoginResponseViewModel> SignInAsync(SignInUserModel inputModel);
    Task SignOutAsync();
    Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel, string token);
}