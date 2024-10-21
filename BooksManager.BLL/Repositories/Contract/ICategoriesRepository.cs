using BooksManager.DAL.Dto;

namespace BooksManager.BLL.Repositories.Contract
{
    public interface ICategoriesRepository
    {
        int AddBook(CategoryDto newCategory);
        int DeleteBook(int id);
        List<CategoryDto> GetAll();
        CategoryDto GetOne(int id);
        int UpdateBook(int id, CategoryDto categoryDto);
    }
}