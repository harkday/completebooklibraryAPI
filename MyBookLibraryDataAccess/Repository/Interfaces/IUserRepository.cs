using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository.Interfaces
{
    public interface IUserRepository : ICrudRepo

    {
        Task<List<User>> GetUsers();
        bool AddUser(User user);
        bool Update(User user);
        void Delete(User user);
        User GetUserById(int id);
        Task<User> GetUserByEmail(string email);
    }

}
