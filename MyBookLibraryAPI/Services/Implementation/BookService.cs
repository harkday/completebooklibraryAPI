using MyBookLibraryAPI.Services.Interface;
using MyBookLibraryAPI.Services.ViewModels;
using MyBookLibraryDataAccess;
using MyBookLibraryDataAccess.Repository.Interfaces;
using MyBookLibraryModel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services
{

    public class BookService:IBookService
    {

        private BookDbContext _context;
        public BookService(BookDbContext context)
        {
            _context = context;

        }
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CreatedAt = DateTime.Now

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

        }

        

        public bool DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> Getallbooks()
        {
            return _context.Books.ToList();
           
        }

        public List<Book> GetBookByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(n => n.Id == bookId);
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
