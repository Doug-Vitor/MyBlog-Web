using AutoMapper;

public class AuthenticationServices : IAuthenticationServices
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IMapper _mapper;
    private readonly HttpContextHelper _httpContextHelper;

    public AuthenticationServices(IAuthenticationRepository authenticationRepository, IMapper mapper, HttpContextHelper httpContextHelper) 
        => (_authenticationRepository, _mapper, _httpContextHelper) = (authenticationRepository, mapper, httpContextHelper);

    public async Task<HttpResponseViewModel> GetByIdAsync(int? id) 
        => await _authenticationRepository.GetByIdAsync(id, _httpContextHelper.GetAuthenticatedUserToken());

    public async Task<HttpResponseViewModel> SignUpAsync(CreateUserInputModel inputModel)
    {
        HttpLoginResponseViewModel responseViewModel = await _authenticationRepository.SignUpAsync(inputModel);
        if (responseViewModel.Success)
            _httpContextHelper.SetAuthenticatedUser(responseViewModel.GeneratedToken);

        return _mapper.Map<HttpResponseViewModel>(responseViewModel);
    }

    public async Task<HttpResponseViewModel> SignInAsync(SignInUserModel inputModel)
    {
        HttpLoginResponseViewModel responseViewModel = await _authenticationRepository.SignInAsync(inputModel);
        if (responseViewModel.Success)
            _httpContextHelper.SetAuthenticatedUser(responseViewModel.GeneratedToken);

        return _mapper.Map<HttpResponseViewModel>(responseViewModel);
    }

    public async Task<ErrorViewModel> UpdateAsync(CreateUserInputModel inputModel) 
        => await _authenticationRepository.UpdateAsync(inputModel, _httpContextHelper.GetAuthenticatedUserToken());
}