using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View(Books());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(new BookViewModel
            {
                
            });
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new BookEditModel());
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
