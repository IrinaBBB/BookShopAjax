using BookShop.Shared.Interfaces;

namespace BookShop.Models
{
    public class AuthorDto : IAuthorDto
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLasttName { get; set; }
        public string AuthorCountry { get; set; }
    }
}
