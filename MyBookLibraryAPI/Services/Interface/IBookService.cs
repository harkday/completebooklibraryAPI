using Microsoft.AspNetCore.Mvc;
using MyBookLibraryAPI.Services.ViewModels;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services.Interface
{
    public interface IBookService
    {
        Task<ObjectResult> AddBook(BookToAddDto model);
        Task<bool> DeleteBook(int bookId);
        Task<Book> UpdateBook(int bookId, UpDateBookDto model);
    }
}
