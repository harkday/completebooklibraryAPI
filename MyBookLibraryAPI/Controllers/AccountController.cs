using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookLibraryDataAccess;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
using MyBookLibraryServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly BookDbContext Context;

        private readonly ITokenService _Token;

        public AccountController(BookDbContext context, ITokenService tokenService)
        {

            Context = context;
            _Token = tokenService;

        }






        [HttpPost("register user")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdto)
        {

            //validating user registration 
            if (await UserExists(registerdto.Email)) return BadRequest("Email already taken");


            using var hmac = new HMACSHA512();

            var user = new User()
            {

                Email = registerdto.Email.ToLower(),
                FirstName = registerdto.FirstName.ToLower(),
                LastName = registerdto.LastName.ToLower(),

                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
                PasswordSalt = hmac.Key

            };

            Context.Users.Add(user);
            await Context.SaveChangesAsync();


            return new UserDto
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

                Token = _Token.CreateToken(user)
            };

           

        }




        [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login(LogInDto logindto)
        {
            var user = await Context.Users.SingleOrDefaultAsync(x => x.Email == logindto.Email);

            if (user == null) return Unauthorized("invalid username");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));

            for (int i = 0; i<ComputedHash.Length; i++){

                if(ComputedHash[i] != user.PasswordHash[i])return  Unauthorized("invalid password");
            }
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _Token.CreateToken(user)
            };


        }
       





        private async Task<bool> UserExists( string Email)
        {

            return await Context.Users.AnyAsync((x => x.Email == Email.ToLower()));

        }

        
    }
}
