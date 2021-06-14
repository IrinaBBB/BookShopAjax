using System.ComponentModel;

namespace BookShop.Shared.Interfaces
{
    public interface IBookViewModel
    {
        [DisplayName("Author's Name")]
        string AuthorName { get; set; }

        [DisplayName("Book's Name")]
        string BookTitle { get; set; }

        [DisplayName("Book's Genre")]
        string Genre { get; set; }

        int Id { get; set; }

        [DisplayName("Year Published")]
        bool IsCheckedOut { get; set; }

        [DisplayName("Book is Checked Out")]
        string YearPublished { get; set; }
    }
}