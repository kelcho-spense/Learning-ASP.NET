using BookMs.Data;
using BookMs.Entities;
using BookMs.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BookMs.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationContext _context;
        public AuthorService(ApplicationContext applicationContext) => _context = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));

        public async Task<Author?> CreateAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            if (await SaveChangesAsync())
            {
                return author;
            }
            return null;
        }

        public async Task<Author?> GetAuthorAsync(Guid id)
        {
            //return await _context.Authors.Where(x => x.Id == id).FirstOrDefaultAsync();
            var authorDetails = from author in _context.Authors
                                where author.Id == id
                                select new
                                {
                                    author.Id,
                                    author.FirstName,
                                    author.LastName,
                                    Books = from book in author.Books
                                            select new
                                            {
                                                book.Id,
                                                book.Title,
                                                book.Description,
                                                book.AuthorId
                                            }
                                };

            if (await SaveChangesAsync())
            {
                return (Author?)authorDetails;
            }
            return null;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<bool> UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            return (await SaveChangesAsync());
        }
        public async Task DeleteAuthorAsync(Author author)
        {
            _context.Authors.Remove(author);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
