using BooksManager.BLL.Repositories.Contract;
using BooksManager.DAL.Data;
using BooksManager.DAL.Dto;
using BooksManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.BLL.Repositories.Implementation
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAll()
        {
            var categories = _context.Categories.Select(x => new CategoryDto
            {
                Description = x.Description,
                Name = x.Name,
            }).ToList();

            return categories;
        }

        public CategoryDto GetOne(int id)
        {
            var category = _context.Categories.Where(e => e.Id == id).Select(x => new CategoryDto
            {
                Description = x.Description,
                Name = x.Name,
            }).FirstOrDefault();

            return category;
        }

        public int AddBook(CategoryDto newCategory)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                Description = newCategory.Description,
            };

            _context.Add(category);
            return _context.SaveChanges();
        }

        public int UpdateBook(int id, CategoryDto categoryDto)
        {
            var category = _context.Categories.FirstOrDefault(b => b.Id == id);


            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            _context.Update(category);
            return _context.SaveChanges();
        }

        public int DeleteBook(int id)
        {
            var category = _context.Categories.FirstOrDefault(b => b.Id == id);
            _context.Remove(category);
            return _context.SaveChanges();
        }
    }
}
