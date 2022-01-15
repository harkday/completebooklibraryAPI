using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookLibraryAPI.Services;
using MyBookLibraryAPI.Services.Interface;
using MyBookLibraryAPI.Services.ViewModels;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Controllers
{

    public class BooksController : BaseApiController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromForm] BookToAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _bookService.AddBook(model);
            return res;
        }

        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _bookService.DeleteBook(bookId);
            return Ok(res);
        }

        [HttpPut("update-book/{id}")]
        public async Task<IActionResult> UpdateBook(int bookId, UpDateBookDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _bookService.UpdateBook(bookId, model);
            return Ok(res);
        }


        //[HttpGet("all-books")]
        /*  public async Task<IActionResult> GetAllBooks(Book)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }
              var res = await _bookService.Getallbooks(Book);
              return Ok();

          }
        */
    
       
    }
}
