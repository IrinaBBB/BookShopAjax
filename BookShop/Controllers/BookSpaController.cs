using BookShop.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookSpaController : Controller
    {
        private readonly IBooksRepository _repository;

        public BookSpaController(IBooksRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetBookList();
            return View(books);
        }
    }
}
