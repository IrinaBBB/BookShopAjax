using BookShop.Data.Entities;
using BookShop.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();
            var book = new BookEditDto();

            if (id != 0)
            {
                var bookEntity = _context.Books.FirstOrDefault(b => b.Id == id);
                book.Id = bookEntity.Id;
                book.BookTitle = bookEntity.Title;
                book.AuthorId = bookEntity.AuthorId;
                book.GenreId = bookEntity.GenreId;
                book.IsCheckedOut = bookEntity.IsCheckedOut;
                book.YearPublished = bookEntity.YearPublished.ToString();
            }

            authors.ForEach(a => book.Authors.Add(new CollectionItem
            {
                Text = $"{a.AuthorFirstName} {a.AuthorLastName}",
                Value = a.Id.ToString()
            }));

            genres.ForEach(g => book.Genres.Add(new CollectionItem
            {
                Text = g.GenreName,
                Value = g.Id.ToString()
            }));

            return book;
        }

        public (bool isSuccessful, int bookId, string message) SaveBook(IBookEditDto book)
        {
            Book bookEntity;

            if (book.Id == 0)
                bookEntity = new Book();
            else
                bookEntity = _context.Books.FirstOrDefault(b => b.Id == book.Id);

            bookEntity.Id = book.Id;
            bookEntity.Title = book.BookTitle;
            bookEntity.GenreId = book.GenreId;
            bookEntity.IsCheckedOut = book.IsCheckedOut;
            bookEntity.YearPublished = Int32.Parse(book.YearPublished);
            bookEntity.AuthorId = book.AuthorId;

            if (book.Id == 0)
                _context.Add(bookEntity);
            else
                _context.Update(bookEntity);

            _context.SaveChanges();

            return (true, bookEntity.Id, "");
        }

        public bool DeleteBook(int id)
        {
            _context.Remove(_context.Books.Single(b => b.Id == id));
            _context.SaveChanges();

            return true;
        }
    }
}
