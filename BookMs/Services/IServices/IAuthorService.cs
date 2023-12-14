using BookMs.Entities;

namespace BookMs.Services.IServices
{
    public interface IAuthorService
    {
        Task<Author> CreateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
        Task<Author?> GetAuthorAsync(Guid id);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<bool> UpdateAuthorAsync(Author author);
    }
}