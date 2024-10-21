using BooksManager.BLL.Repositories.Contract;
using BooksManager.DAL.Dto;
using BooksManager.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllBooks() {
            var result = _bookRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetOne/{id:int}")]
        public IActionResult GetBook(int id)
        {
            var result = _bookRepository.GetOne(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook(BookDto book)
        {
            var result = _bookRepository.AddBook(book);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateBook(int id , BookDto book)
        {
            var result = _bookRepository.UpdateBook(id, book);
            return Ok(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookRepository.DeleteBook(id);
            return Ok(result);
        }

    }
}
