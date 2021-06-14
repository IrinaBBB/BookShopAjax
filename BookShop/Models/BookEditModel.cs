using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookShop.Models
{
    public class BookEditModel
    {
        public int Id { get; set; }

        [DisplayName("Book Title")]
        public string BookTitle { get; set; }

        [DisplayName("Book Author")]
        public int AuthorId { get; set; }

        [DisplayName("Book Genre")]
        public int GenreId { get; set; }

        [DisplayName("The Year Book was published")]
        public string YearPublished { get; set; }

        [DisplayName("Book was CHecked Out")]
        public bool IsCheckedOut { get; set; }

        public IList<SelectListItem> Authors { get; set; } =
            new List<SelectListItem> { new SelectListItem { Value = null, Text = "Select Author" } };

        public IList<SelectListItem> Genres { get; set; } =
            new List<SelectListItem> { new SelectListItem { Value = null, Text = "Select Genre" } };
    }
}
