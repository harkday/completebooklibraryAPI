using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository
{
      public  interface ICrudRepo
    {
        Task<bool> Add<T>(T entity);
    }
}
