using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services.Interface
{
    public interface IJWTService
    {
        string GenerateToken(User user, List<string> userRoles);
    }
}
