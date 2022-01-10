using MyBookLibraryAPI.Services.ViewModels;
using MyBookLibraryModel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services.Interface
{
    public interface IBookService
    {
        void AddBook(BookVM book);
        bool Update(Book book);
        bool DeleteBook(Book book);
        Book GetBookById(int bookId);
        List<Book> Getallbooks();
        List<Book> GetBookByCategory(int categoryId);
        Book GetBookByName(string name);
    }
}
