using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBookLibraryDataAccess;
using MyBookLibraryServices.Repository.Implimentation;
using MyBookLibraryServices.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookLibraryAPI.Controllers.Extension
{
    public static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Config)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddDbContext<BookDbContext>(options =>

            {
                options.UseSqlServer(Config.GetConnectionString("DefaultConnectionString"));

            });
            return services;
        }
    }
}
