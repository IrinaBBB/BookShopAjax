using BookShop.Shared.Interfaces;
using System.Collections.Generic;

namespace BookShop.Data.Repositories
{
    public interface IBooksRepository
    {
        bool DeleteBook(int id);
        IBookEditDto EditBook(int id);
        IEnumerable<IBookListItemModel> GetBookList();
        bool SaveBook(IBookEditDto book);
        IBookViewModel ViewBookById(int id);
    }
}