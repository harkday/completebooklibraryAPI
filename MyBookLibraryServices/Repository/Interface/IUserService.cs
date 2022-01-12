using MyBookLibraryAPI.Services.Implementation;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryServices.Repository.Interface
{
    public interface IUserService
    {
        Task<List<User>> Users();
        Task<RegisterSuccessDto> Register(User user, string password);
        Task<LoginSuccess> Login(string email, string password);
        Task<User> GetUser(string email);
        Task DeleteUser(string id);
    }
}
