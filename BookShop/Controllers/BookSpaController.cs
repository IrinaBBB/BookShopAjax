using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookSpaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
