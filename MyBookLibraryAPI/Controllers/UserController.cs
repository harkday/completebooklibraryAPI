using Microsoft.AspNetCore.Mvc;
using MyBookLibraryAPI.Services.Implementation;
using MyBookLibraryDataAccess;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
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

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //return await _userService.Users();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            //return await _context.Users.FindAsync(id);
            return Ok();

        }

        [HttpPost("add-user")]
        public ActionResult AddUser(RegisterDto user)
        {
            //return Ok(_context.Users.Add(user));
            return Ok();
        }

    }
}
