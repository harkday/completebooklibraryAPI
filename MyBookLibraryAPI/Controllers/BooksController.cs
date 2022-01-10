using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookLibraryAPI.Services;
using MyBookLibraryAPI.Services.Interface;
using MyBookLibraryAPI.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Controllers
{
 
    public class BooksController : BaseApiController
    {
        public IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.Getallbooks();
            return Ok(allBooks);
        }


        [HttpGet("get-bookid /{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }
    }
}
