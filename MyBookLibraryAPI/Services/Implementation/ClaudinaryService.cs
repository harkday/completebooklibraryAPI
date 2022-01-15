using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using MyBookLibraryAPI.Services.Interface;
using MyBookLibraryModel.DTOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Services.Implementation
{
    public class ClaudinaryService: IClaudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public ClaudinaryService()
        {
            Account account = new Account();
            account.Cloud = "dvxxdmpsc";
            account.ApiKey = "633295917353356";
            account.ApiSecret = "lfcAz_MY93N_g_aNCMUofGT46v8";
            _cloudinary = new Cloudinary(account); ;
        }

        public bool DeleteFiles(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            var deleteResult = _cloudinary.DestroyAsync(deletionParams).Result;
            if(deleteResult.Result.ToLower() == "ok")
            {
                return true;
            }

            return false;
        }

        public PhotoUploadResult UploadPHoto(IFormFile file)
        {
             using var str = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, str)
            };

            var uploadResult = _cloudinary.UploadAsync(uploadParams).Result;

            if(uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new PhotoUploadResult
                {
                    PublicId = uploadResult.PublicId,
                    Ulr = uploadResult.Url.ToString()
                };
            }
            
            return null;
        }
    }
}
