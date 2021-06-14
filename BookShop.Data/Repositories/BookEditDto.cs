using BookShop.Shared.Interfaces;
using System.Collections.Generic;

namespace BookShop.Data.Repositories
{
    public class BookEditDto : IBookEditDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string YearPublished { get; set; }
        public bool IsCheckedOut { get; set; }

        public IList<ICollectionItem> Authors { get; set; } = new List<ICollectionItem>();
        public IList<ICollectionItem> Genres { get; set; } = new List<ICollectionItem>();
    }
}
