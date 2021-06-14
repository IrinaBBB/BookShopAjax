namespace BookShop.Shared.Interfaces
{
    public interface IBookListItemModel
    {
        string AuthorName { get; set; }
        string BookTitle { get; set; }
        string Genre { get; set; }
        int Id { get; set; }
    }
}