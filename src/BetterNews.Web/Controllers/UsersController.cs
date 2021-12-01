﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    private readonly IUserServices _userServices;
    private readonly IMapper _mapper;

    public UsersController(IUserServices userServices, IMapper mapper) =>
        (_userServices, _mapper) = (userServices, mapper);

    public async Task<IActionResult> GetById(int? id)
    {
        HttpResponseViewModel responseViewModel = await _userServices.GetByIdAsync(id);
        return responseViewModel.Success ? View(responseViewModel.UserViewModel) : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }

    public async Task<IActionResult> SignUp(CreateUserInputModel inputModel)
    {
        HttpResponseViewModel responseViewModel = await _userServices.SignUpAsync(inputModel);
        return responseViewModel.Success ? RedirectToHomeIndex() : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }

    public async Task<IActionResult> SignIn(SignInUserModel inputModel)
    {
        HttpResponseViewModel responseViewModel = await _userServices.SignInAsync(inputModel);
        return responseViewModel.Success ? RedirectToHomeIndex() : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }

    public async Task<IActionResult> SignOut()
    {
        await _userServices.SignOutAsync();
        return RedirectToHomeIndex();
    }

    [HttpGet]
    public async Task<IActionResult> Update(int? id)
    {
        HttpResponseViewModel responseViewModel = await _userServices.GetByIdAsync(id);
        return responseViewModel.Success ? View(_mapper.Map<CreateUserInputModel>(responseViewModel.UserViewModel)) : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(CreateUserInputModel inputModel)
    {
        ErrorViewModel viewModel = await _userServices.UpdateAsync(inputModel);

        return viewModel == null ? RedirectToHomeIndex() : RedirectToErrorAction(viewModel);
    }

    private IActionResult RedirectToErrorAction(ErrorViewModel viewModel) =>
        RedirectToAction(nameof(Error), new { errors = viewModel.ErrorsMessages });

    private IActionResult RedirectToHomeIndex() => View("Index", "Home");

    public IActionResult Error(List<string> errors) => View(new ErrorViewModel(errors));
}
