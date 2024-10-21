using BooksManager.BLL.Repositories.Contract;
using BooksManager.DAL.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoryRepository)
        {
            _categoriesRepository = categoryRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllBooks()
        {
            var result = _categoriesRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetOne/{id:int}")]
        public IActionResult GetBook(int id)
        {
            var result = _categoriesRepository.GetOne(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook(CategoryDto category)
        {
            var result = _categoriesRepository.AddBook(category);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateBook(int id, CategoryDto category)
        {
            var result = _categoriesRepository.UpdateBook(id, category);
            return Ok(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _categoriesRepository.DeleteBook(id);
            return Ok(result);
        }
    }
}
