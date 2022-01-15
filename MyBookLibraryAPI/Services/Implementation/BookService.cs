using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBookLibraryAPI.Services.Interface;
using MyBookLibraryAPI.Services.ViewModels;
using MyBookLibraryDataAccess;
using MyBookLibraryDataAccess.Repository.Interfaces;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services
{

    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        private readonly IClaudinaryService _claudinary;

        public BookService(IBookRepository bookRepo, IMapper mapper, IClaudinaryService claudinary)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
            _claudinary = claudinary;
        }

        public async Task<ObjectResult> AddBook(BookToAddDto model)
        {
            var imageUploadResult = _claudinary.UploadPHoto(model.Cover);
            if (imageUploadResult == null)
                return new BadRequestObjectResult("Image Not uploaded");

            var book = _mapper.Map<Book>(model);
            //var book = new Book
            //{
            //    Title = model.Title,
            //    ISBN = model.ISBN,
            //    CategoryId = model.CategoryId,
            //    Author = model.Author,
            //    Description = model.Description
            //};

            book.CoverUrl = imageUploadResult.Ulr;
            book.PublicId = imageUploadResult.PublicId;
            var addRes = _bookRepo.Addbook(book);

            if (!addRes)
            {
                _claudinary.DeleteFiles(imageUploadResult.PublicId);
                return new UnprocessableEntityObjectResult("Unable to add book");
            }
            var bookToReturn = _mapper.Map<BookToReturnDto>(book);
            return new OkObjectResult(bookToReturn);
        }

      

        public async Task<bool> DeleteBook(int bookId)
        {
            var book = await _bookRepo.GetBookById(bookId);

            if(book != null)
            {
                await _bookRepo.DeleteBook(book);
                return true;
            }

            return false;
            
   
        }

        public async Task<Book> UpdateBook(int bookId, UpDateBookDto model)
        {
            var book = await _bookRepo.GetBookById(bookId);
            var res = false;

            if(book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;

                res = await _bookRepo.Update(book);
            }

            if (res) return book;

            return null;
        }

        //public async List<Book> GetAllBooks(Book) => await  BookDbContext.Book.ToList();
            
        
       
    }
}
