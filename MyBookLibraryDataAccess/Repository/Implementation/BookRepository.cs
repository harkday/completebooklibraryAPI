using MyBookLibraryDataAccess.Repository.Interfaces;
using MyBookLibraryModel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        public bool Addbook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> Getallbooks()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBookByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public Book GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
