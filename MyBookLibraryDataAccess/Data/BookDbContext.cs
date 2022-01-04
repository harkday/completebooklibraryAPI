using Microsoft.EntityFrameworkCore;
using MyBookLibraryModel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess
{
    public class BookDbContext: DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        
    }
}
