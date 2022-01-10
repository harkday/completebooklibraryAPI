using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryModel.Data.Model
{
   public  class Book :BaseEntity
   {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string  ISBN { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public List<BookUser> BookUsers { get; set; }

        public Book()
        {
            BookUsers = new List<BookUser>();
        }





    }
}
