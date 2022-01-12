using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookLibraryAPI.Services.Implementation;
using MyBookLibraryDataAccess;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
using MyBookLibraryServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetUsers()
        {
            var listOfUsers = new List<User>();
            var users = await _userService.Users();
            foreach (var user in users)
            {
                listOfUsers.Add(user);
            }
            return Ok(users);
        }

        [Authorize]

        [HttpGet("get-by-email")]
        public async Task<ActionResult> GetUser(string email)
        {
            var user = await _userService.GetUser(email);
            return Ok(user);

        }

        [HttpPost("add-user")]
        public ActionResult AddUser(RegisterDto user)
        {
            //return Ok(_context.Users.Add(user));
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string email)
        {
            await _userService.DeleteUser(email);
            return Ok();
        }




    }
}
