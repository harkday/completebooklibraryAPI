using Microsoft.AspNetCore.Http;
using MyBookLibraryModel.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services.Interface
{
    public interface IClaudinaryService
    {
        PhotoUploadResult UploadPHoto(IFormFile file);
        bool DeleteFiles(string publicIds);
    }
}
