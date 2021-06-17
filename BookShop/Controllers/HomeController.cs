using BookShop.Data.Repositories;
using BookShop.Models;
using BookShop.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository _repository;

        public HomeController(IBooksRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetBookList();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var bookItem = _repository.ViewBookById(id);
            return View(bookItem);
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

        public ActionResult EditBook(int id)
        {
            var bookDto = _repository.EditBook(id);

            var book = new BookEditModel
            {
                Id = bookDto.Id,
                BookTitle = bookDto.BookTitle,
                AuthorId = bookDto.AuthorId,
                GenreId = bookDto.GenreId,
                YearPublished = bookDto.YearPublished,
                IsCheckedOut = bookDto.IsCheckedOut
            };

            bookDto.Authors.ToList()
                .ForEach(a => book.Authors.Add(
                        new SelectListItem { Text = a.Text, Value = a.Value}
                    ));

            bookDto.Genres.ToList()
                .ForEach(g => book.Genres.Add(
                        new SelectListItem { Text = g.Text, Value = g.Value }
                    ));

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(BookEditModel book)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(book);

                var bookDto = new BookEditDto
                {
                    AuthorId = book.AuthorId,
                    BookTitle = book.BookTitle,
                    GenreId = book.GenreId,
                    YearPublished = book.YearPublished,
                    IsCheckedOut = book.IsCheckedOut,
                    Id = book.Id
                };

                _repository.SaveBook(bookDto);

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
