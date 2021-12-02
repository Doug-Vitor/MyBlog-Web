using Microsoft.AspNetCore.Mvc;

namespace BetterNews.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Error(ErrorViewModel viewModel) => View(viewModel);
    }
}
