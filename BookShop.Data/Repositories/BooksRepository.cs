using BookShop.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IBookListItemModel> GetBookList()
        {
            var books = _context.Books
                .Include(a => a.Author)
                .Include(g => g.Genre)
                .ToList();

            var booksList = books.Select(b => new ListItem
            {
                Id = b.Id,
                AuthorName = $"{b.Author.AuthorFirstName} {b.Author.AuthorLastName}",
                BookTitle = b.Title,
                Genre = b.Genre.GenreName
            }).ToList();

            return booksList;
        }

        public IBookViewModel ViewBookById(int id)
        {
            var bookEntity = _context.Books
                .Include(a => a.Author)
                .Include(g => g.Genre)
                .FirstOrDefault(b => b.Id == id);

            var book = new BookDto
            {
                Id = bookEntity.Id,
                AuthorName = $"{bookEntity.Author.AuthorFirstName} {bookEntity.Author.AuthorLastName}",
                BookTitle = bookEntity.Title,
                Genre = bookEntity.Genre.GenreName,
                YearPublished = bookEntity.YearPublished.ToString(),
                IsCheckedOut = bookEntity.IsCheckedOut
            };

            return book;
        }

        public IBookEditDto EditBook(int id)
        {
            return null;
        }

        public bool SaveBook(IBookEditDto book)
        {
            return false;
        }

        public bool DeleteBook(int id)
        {
            return false;
        }
    }
}
