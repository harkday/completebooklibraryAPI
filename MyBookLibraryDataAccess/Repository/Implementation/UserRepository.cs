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
    public class UserRepository : IUserRepository
    {
        private readonly BookDbContext _context;

        public UserRepository(BookDbContext context)
        {
            _context = context;
        }
        public Task<bool> Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            var newUser = _context.Users.Add(user);
            _context.SaveChanges();

            if(newUser != null)
            {
                return true;
            }

            return false;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public User GetUserById(int id)
        {
            var user =  _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            users = await _context.Users.ToListAsync();

            return users;
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
