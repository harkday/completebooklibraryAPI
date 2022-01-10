using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryModel.Model
{
   public class LogIn:BaseEntity
    {
        public string UserName { get; set; }

        public string Email { get; set; }


        public string Password { get; set; }
    }
}
