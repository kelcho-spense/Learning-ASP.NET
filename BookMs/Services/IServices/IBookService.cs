using BookMs.Entities;
using BookMs.Models;

namespace BookMs.Services.IServices
{
    public interface IBookService
    {
        Task<Book?> AddBookAsync(Book book);
        Task<string?> CreateBooksAsync(List<Book> books);
        Task DeleteBookAsync(Book book);
        void DeleteBookAsync(Guid id);
        Task<Book?> GetBookAsync(Guid id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<bool> SaveChangesAsync();
        Task<bool> UpdateBookAsync(Book book);
    }
}