using MyBookLibraryModel.Model;
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
        Task<bool> Update(Book book);
        Task<bool> DeleteBook(Book book);
        Task<Book> GetBookById(int bookId);
        List<Book> Getallbooks();
    }
}
