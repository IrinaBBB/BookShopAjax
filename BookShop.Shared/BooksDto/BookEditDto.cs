using BookShop.Shared.Interfaces;
using System.Collections.Generic;

namespace BookShop.Shared.BooksDto
{
    public class BookEditDto : IBookEditDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string AuthorId { get; set; }
        public string GenreId { get; set; }
        public string YearPublished { get; set; }
        public bool IsCheckedOut { get; set; }

        public IList<ICollectionItem> Authors { get; set; } = new List<ICollectionItem>();
        public IList<ICollectionItem> Genres { get; set; } = new List<ICollectionItem>();
    }
}
