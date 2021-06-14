using BookShop.Shared.Interfaces;


namespace BookShop.Data.Repositories
{
    public class BookDto : IBookViewModel
    {
        public string AuthorName { get; set; }
        public string BookTitle { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }
        public bool IsCheckedOut { get; set; }
        public string YearPublished { get; set; }
    }
}
