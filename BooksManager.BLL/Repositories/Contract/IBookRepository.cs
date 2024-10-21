using BooksManager.DAL.Dto;
using BooksManager.DAL.Models;

namespace BooksManager.BLL.Repositories.Contract
{
    public interface IBookRepository
    {
        List<BookDto> GetAll();
        BookDto GetOne(int id);
        int AddBook(BookDto newBook);
        int UpdateBook(int id, BookDto newBook);
        int DeleteBook(int id);
    }
}