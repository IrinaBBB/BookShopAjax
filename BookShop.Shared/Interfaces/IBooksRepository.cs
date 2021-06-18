using BookShop.Shared.Interfaces;
using System.Collections.Generic;

namespace BookShop.Shared.Interfaces
{
    public interface IBooksRepository
    {
        bool DeleteBook(int id);
        IBookEditDto EditBook(int id);
        IEnumerable<IBookListItemModel> GetBookList();
        (bool isSuccessful, int bookId, string message) SaveBook(IBookEditDto book);
        IBookViewModel ViewBookById(int id);
    }
}