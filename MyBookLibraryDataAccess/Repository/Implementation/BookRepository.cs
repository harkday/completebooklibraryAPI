using Microsoft.EntityFrameworkCore;
using MyBookLibraryDataAccess.Repository.Interfaces;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _ctx;

        public BookRepository(BookDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool Addbook(Book book)
        {

            _ctx.Books.Add(book);
           // _ctx.Books.Add(book);
            return _ctx.SaveChanges() > 0;
        }

        public async Task<bool> DeleteBook(Book book)
        {
            _ctx.Books.Remove(book);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public List<Book> Getallbooks()
        {
            return _ctx.Books.ToList();
        }
        public async Task<Book> GetBookById(int bookId)
        {
            return await _ctx.Books.FindAsync(bookId);
        }

        public async Task<bool> Update(Book book)
        {
            _ctx.Books.Update(book);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
