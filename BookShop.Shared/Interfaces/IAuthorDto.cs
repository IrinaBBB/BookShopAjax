namespace BookShop.Shared.Interfaces
{
    public interface IAuthorDto
    {
        int Id { get; set; }
        string AuthorFirstName { get; set; }
        string AuthorLasttName { get; set; }
        string AuthorCountry { get; set; }
    }
}
