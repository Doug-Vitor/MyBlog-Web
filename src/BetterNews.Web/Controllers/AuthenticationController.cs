using Microsoft.AspNetCore.Mvc;

public class AuthenticationController : Controller
{
    private readonly IAuthenticationRepository _authenticationRepository;

    public AuthenticationController(IAuthenticationRepository authenticationRepository) =>
        _authenticationRepository = authenticationRepository;

    private IActionResult RedirectToErrorAction(ErrorViewModel viewModel) =>
        RedirectToAction(nameof(Error), new { errors = viewModel.ErrorsMessages });

    public IActionResult Error(List<string> errors) => View(new ErrorViewModel(errors));
}
