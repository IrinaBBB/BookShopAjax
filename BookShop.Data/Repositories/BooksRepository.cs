using BookShop.Shared.Interfaces;
using System.Collections.Generic;

namespace BookShop.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public IEnumerable<IBookListItemModel> GetBookList()
        {
            return null;
        }

        public IBookViewModel ViewBookById(int id)
        {
            return null;
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
