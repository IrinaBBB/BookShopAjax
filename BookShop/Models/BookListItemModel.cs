using BookShop.Shared.Interfaces;

namespace BookShop.Models
{
    public class BookListItemModel : IBookListItemModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
}
