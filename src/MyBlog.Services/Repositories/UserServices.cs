﻿using AutoMapper;

public class UserServices : IUserServices
{
    private readonly IUserRepository _authenticationRepository;
    private readonly IMapper _mapper;
    private readonly HttpContextHelper _httpContextHelper;

    public UserServices(IUserRepository authenticationRepository, IMapper mapper, HttpContextHelper httpContextHelper) 
        => (_authenticationRepository, _mapper, _httpContextHelper) = (authenticationRepository, mapper, httpContextHelper);

    public async Task<HttpResponseViewModel> GetByIdAsync(int? id) 
        => await _authenticationRepository.GetByIdAsync(id, await _httpContextHelper.GetAuthenticatedUserTokenAsync());

    public async Task<HttpResponseViewModel> SignUpAsync(CreateUserInputModel inputModel)
    {
        HttpLoginResponseViewModel responseViewModel = await _authenticationRepository.SignUpAsync(inputModel);
        if (responseViewModel.Success)
            await _httpContextHelper.SetAuthenticatedUserAsync(responseViewModel.GeneratedToken);

        return _mapper.Map<HttpResponseViewModel>(responseViewModel);
    }

    public async Task<HttpResponseViewModel> SignInAsync(SignInUserModel inputModel)
    {
        HttpLoginResponseViewModel responseViewModel = await _authenticationRepository.SignInAsync(inputModel);
        if (responseViewModel.Success)
            await _httpContextHelper.SetAuthenticatedUserAsync(responseViewModel.GeneratedToken);

        return _mapper.Map<HttpResponseViewModel>(responseViewModel);
    }
    public async Task SignOutAsync()
    {
        await _authenticationRepository.SignOutAsync();
        await _httpContextHelper.SignOutAuthenticatedUserAsync();
    }

    public async Task<HttpResponseViewModel> GetAuthenticatedUserAsync() 
        => await _authenticationRepository.GetAuthenticatedUserAsync(await _httpContextHelper.GetAuthenticatedUserTokenAsync());

    public async Task<ErrorViewModel> UpdateAuthenticatedUserAsync(CreateUserInputModel inputModel) 
        => await _authenticationRepository.UpdateAuthenticatedUserAsync(inputModel, await _httpContextHelper.GetAuthenticatedUserTokenAsync());
}