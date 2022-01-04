using MyBookLibraryDataAccess.Repository.Interfaces;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryDataAccess.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
