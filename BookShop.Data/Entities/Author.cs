using System.Collections.Generic;

namespace BookShop.Data
{
    public partial class Author
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorCountry { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
