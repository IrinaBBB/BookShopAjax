using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class BookEditModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string AuthorId { get; set; }
        public string GenreId { get; set; }
        public string YearPublished { get; set; }
        public bool IsCheckedOut { get; set; }

        public IList<SelectListItem> Authors { get; set; } =
            new List<SelectListItem> { new SelectListItem { Value = null, Text = "Select Author" } };

        public IList<SelectListItem> Genres { get; set; } =
            new List<SelectListItem> { new SelectListItem { Value = null, Text = "Select Genre" } };
    }
}
