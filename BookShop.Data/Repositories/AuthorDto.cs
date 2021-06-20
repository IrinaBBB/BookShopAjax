using BookShop.Shared.Interfaces;

namespace BookShop.Data.Repositories
{
    public class AuthorDto : IAuthorDto
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLasttName { get; set; }
        public string AuthorCountry { get; set; }
    }
}
