using BooksManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.DAL.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public int Price { get; set; }

        public string Author { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}
