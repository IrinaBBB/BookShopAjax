﻿using BookShop.Shared.Interfaces;
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

        private bool IsAjaxRequest() => Request.Headers["X-Requested-With"] == "XMLHttpRequest";
    }
}
