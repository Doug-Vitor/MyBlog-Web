using Microsoft.AspNetCore.Mvc;

namespace BetterNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;

        public HomeController(IPostServices postServices) => _postServices = postServices;

        public async Task<IActionResult> Index() => View(await _postServices.GetAllAsync());
        public IActionResult Error(ErrorViewModel viewModel) => View(viewModel);
    }
}
