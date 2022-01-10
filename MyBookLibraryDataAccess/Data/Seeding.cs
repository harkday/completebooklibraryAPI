using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyBookLibraryModel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository
{
   public  class Seeding
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "things fall apart",
                        Description = "1st Edition",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        ISBN = "97803854745-SBNT",
                        Author = "Chinua Achebe",
                        Genre = "fiction",
                       // BookUsers = {}


                    },
                    new Book()
                    {
                        Title = "a new man",
                        Description = "2st Edition",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        ISBN = "97803854745-SBNT",
                        Author = "Segun Akanni",
                        Genre = "fiction",
                        //BookUsers = { }

                    } );
                    context.SaveChanges();

                }
            }

        }
    }
}
