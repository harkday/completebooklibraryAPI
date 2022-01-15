using AutoMapper;
using MyBookLibraryModel.DTOS;
using MyBookLibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.MappingProfiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<BookToAddDto, Book>();
            CreateMap<Book, BookToReturnDto>();
        }
    }
}
