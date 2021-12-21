using AutoMapper;
using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    private readonly IUserServices _userServices;
    private readonly IMapper _mapper;

    public UsersController(IUserServices userServices, IMapper mapper) =>
        (_userServices, _mapper) = (userServices, mapper);

    public async Task<IActionResult> GetById(int? id)
    {
        HttpResponseViewModel<UserViewModel> responseViewModel = await _userServices.GetByIdAsync(id);
        return responseViewModel.Success ? View(responseViewModel.ViewModel) : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }

    [HttpGet]
    public IActionResult SignUp() => View();

    [HttpPost]
    public async Task<IActionResult> SignUp(CreateUserInputModel inputModel)
    {
        HttpResponseViewModel<UserViewModel> responseViewModel = await _userServices.SignUpAsync(inputModel);
        return responseViewModel.Success ? RedirectToHomeIndex() : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }

    [HttpGet]
    public IActionResult SignIn() => View();

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInUserModel inputModel)
   {
        HttpResponseViewModel<UserViewModel> responseViewModel = await _userServices.SignInAsync(inputModel);
        return responseViewModel.Success ? RedirectToHomeIndex() : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }

    public async Task<RedirectToActionResult> SignOut()
    {
        await _userServices.SignOutAsync();
        return RedirectToHomeIndex();
    }

    [HttpGet]
    public async Task<IActionResult> MyProfile()
    {
        HttpResponseViewModel<UserViewModel> responseViewModel = await _userServices.GetAuthenticatedUserAsync();
        return responseViewModel.Success ? View(_mapper.Map<CreateUserInputModel>(responseViewModel.ViewModel)) : RedirectToErrorAction(responseViewModel.ErrorViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(CreateUserInputModel inputModel)
    {
        ErrorViewModel viewModel = await _userServices.UpdateAuthenticatedUserAsync(inputModel);
        return viewModel == null ? RedirectToHomeIndex() : RedirectToErrorAction(viewModel);
    }

    private RedirectToActionResult RedirectToErrorAction(ErrorViewModel viewModel) =>
        RedirectToAction("Error", "Home", viewModel);

    private RedirectToActionResult RedirectToHomeIndex() => RedirectToAction("Index", "Home");
}
