using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibraryModel.DTOS
{
    public class BookToAddDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please provide a book cover photo")]
        public IFormFile Cover { get; set; }
    }
}
