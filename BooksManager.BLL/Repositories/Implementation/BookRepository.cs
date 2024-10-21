using BooksManager.BLL.Repositories.Contract;
using BooksManager.DAL.Data;
using BooksManager.DAL.Dto;
using BooksManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksManager.BLL.Repositories.Implementation
{

    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BookDto> GetAll()
        {
            var books = _context.Books.Select(x => new BookDto
            {
                Author = x.Author,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                CategoryDescription = x.Category.Description,
                CategoryName = x.Category.Name,
            }).ToList();

            return books;
        }

        public BookDto GetOne(int id)
        {
            var bookDto = _context.Books.Where(b => b.Id == id).Select(x => new BookDto
            {
                Author = x.Author,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                CategoryDescription = x.Category.Description,
                CategoryName = x.Category.Name,
            }).FirstOrDefault();

            return bookDto;
        }

        public int AddBook(BookDto newBook)
        {
            var book = new Book { 
                Name = newBook.Name,
                Description = newBook.Description,
                Price= newBook.Price,
                Stock= newBook.Stock,
                Author = newBook.Author,
                Category = new Category
                {
                    Name = newBook.CategoryName,
                    Description= newBook.CategoryDescription,
                }
            };

            _context.Add(book);
            return _context.SaveChanges();
        }

        public int UpdateBook(int id, BookDto newBook)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            

            book.Author = newBook.Author;
            book.Stock = newBook.Stock;
            book.Description = newBook.Description;
            book.Price = newBook.Price;

            _context.Update(book);
            return _context.SaveChanges();
        }

        public int DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            _context.Remove(book);
            return _context.SaveChanges();
        }
    }
}
