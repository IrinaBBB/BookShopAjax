using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Books());
        }

        public ActionResult Details(int id)
        {
            var books = Books();
            var bookModel = books.FirstOrDefault(book => book.Id == id);
            var book = new BookViewModel
            {
                Id = bookModel.Id,
                BookTitle = bookModel.BookTitle,
                AuthorName = bookModel.AuthorName,
                Genre = bookModel.Genre
            };

            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(new BookEditModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IList<BookListItemModel> Books() =>
            new List<BookListItemModel>
            {
                new BookListItemModel
                {
                    Id = 1, 
                    AuthorName = "Jules Verne",
                    BookTitle = "The Mysterious Island",
                    Genre = "Adventure fiction"
                },
                new BookListItemModel
                {
                    Id = 2,
                    AuthorName = "Victor Hugo",
                    BookTitle = "Notre-Dame de Paris",
                    Genre = "Gothic fiction"
                },
                new BookListItemModel
                {
                    Id = 3,
                    AuthorName = "Herbert George Wells",
                    BookTitle = "The War of the Worlds",
                    Genre = "Science fiction"
                }
            };

    }
}
