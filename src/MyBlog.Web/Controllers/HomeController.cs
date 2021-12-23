using Microsoft.AspNetCore.Mvc;

namespace BetterNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;

        public HomeController(IPostServices postServices) => _postServices = postServices;

        public async Task<IActionResult> Index()
        {
            HttpResponseViewModel<IEnumerable<PostViewModel>> result = await _postServices.GetAllAsync();
            if (result.Success)
                return View(new Tuple<CreatePostInputModel, IEnumerable<PostViewModel>>(new(string.Empty), result.ViewModel));

            return RedirectToAction(nameof(Error), result.ErrorViewModel);
        }

        public IActionResult Error(ErrorViewModel viewModel) => View(viewModel);
    }
}
