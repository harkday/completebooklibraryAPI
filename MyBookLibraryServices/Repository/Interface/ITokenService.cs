using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryServices.Repository.Interface
{
   public  interface ITokenService
    { 
        string CreateToken(User user);
        string GenerateToken(User user, List<string> userRoles);


    }
}
