using BookShop.Data.Repositories;
using BookShop.Models;
using BookShop.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
            return View();
        }

        public IActionResult GetBookList()
        {
            if (!IsAjaxRequest())
                return Content("Information cannot be displayed");

            var books = _repository.GetBookList();
            return Json(books);
        }

        public IActionResult ViewBook(int id)
        {
            if (!IsAjaxRequest())
                return Content("Information cannot be displayed");

            var bookItem = _repository.ViewBookById(id);
            return PartialView("_ViewBook", bookItem);
        }

        public ActionResult EditBook(int id)
        {
            if (!IsAjaxRequest())
                return Content("Information cannot be displayed");

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
                        new SelectListItem 
                        { 
                            Text = a.Text, 
                            Value = a.Value,
                            Selected = book.AuthorId.ToString() == a.Value
                        }
                    ));

            bookDto.Genres.ToList()
                .ForEach(g => book.Genres.Add(
                        new SelectListItem 
                        { 
                            Text = g.Text, 
                            Value = g.Value,
                            Selected = book.GenreId.ToString() == g.Value
                        }
                    ));

            var authorsJson = JsonConvert.SerializeObject(book.Authors);
            var genresJson = JsonConvert.SerializeObject(book.Genres);

            ViewBag.AuthorsList = authorsJson;
            ViewBag.GenresList = genresJson;

            return PartialView("_EditBook", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(IFormCollection col, BookEditModel book)
        {
            if (!ModelState.IsValid)
            {
                var authors = col["AuthorsList"];
                var genres = col["GenresList"];
                book.Authors = JsonConvert.DeserializeObject<IList<SelectListItem>>(authors);
                book.Genres = JsonConvert.DeserializeObject<IList<SelectListItem>>(genres);
                ViewBag.AuthorsList = authors;
                ViewBag.GenresList = genres;
                return PartialView("_EditBook", book);

            }

            var bookDto = new BookEditDto
            {
                AuthorId = book.AuthorId,
                BookTitle = book.BookTitle,
                GenreId = book.GenreId,
                YearPublished = book.YearPublished,
                IsCheckedOut = book.IsCheckedOut,
                Id = book.Id
            };

            var result = _repository.SaveBook(bookDto);

            var bookItem = _repository.ViewBookById(result.bookId);

            return PartialView("_ViewBook", bookItem);
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            if (!IsAjaxRequest())
                return Content("Information cannot be displayed");

            _repository.DeleteBook(id);
            return Ok();
        }

        public IActionResult AddNewAuthor()
        {
            if (!IsAjaxRequest())
                return Content("Information cannot be displayed");

            return PartialView("_AddNewAuthor", new Models.AuthorDto());
        }

        public IActionResult AddNewGenre()
        {
            if (!IsAjaxRequest())
                return Content("Information cannot be displayed");


            return Ok();
        }





        private bool IsAjaxRequest() => Request.Headers["X-Requested-With"] == "XMLHttpRequest";
    }
}
