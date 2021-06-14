using System.Collections.Generic;

namespace BookShop.Shared.Interfaces
{
    public interface IBookEditDto
    {
        int Id { get; set; }
        string BookTitle { get; set; }
        string AuthorId { get; set; }
        string GenreId { get; set; }
        string YearPublished { get; set; }
        bool IsCheckedOut { get; set; }

        IList<ICollectionItem> Authors { get; set; }
        IList<ICollectionItem> Genres { get; set; }
    }
}