using BookShop.Shared.Interfaces;
using System.ComponentModel;

namespace BookShop.Models
{
    public class BookViewModel : IBookViewModel
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string AuthorName { get; set; }

        public string Genre { get; set; }

        public string YearPublished { get; set; }

        public bool IsCheckedOut { get; set; }
    }
}
