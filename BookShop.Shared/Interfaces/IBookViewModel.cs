namespace BookShop.Shared.Interfaces
{
    public interface IBookViewModel
    {
        string AuthorName { get; set; }
        string BookTitle { get; set; }
        string Genre { get; set; }
        int Id { get; set; }
        bool IsCheckedOut { get; set; }
        string YearPublished { get; set; }
    }
}