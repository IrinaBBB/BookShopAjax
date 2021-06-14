using BookShop.Shared.Interfaces;

namespace BookShop.Data.Repositories
{
    public class ListItem : IBookListItemModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
}
