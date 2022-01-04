using MyBookLibraryModel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository.Interfaces
{
    public interface IBookRepository
    {
        bool Addbook(Book book);
        bool Update(Book book);
        bool DeleteBook(Book book);
        Book GetBookById(int bookId);
        List<Book> Getallbooks();
        List<Book> GetBookByCategory(int categoryId);
        Book GetBookByName(string name);
    }
}
