using BookMs.Data;
using BookMs.Entities;
using BookMs.Models;
using BookMs.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BookMs.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext _context;
        public BookService(ApplicationContext bookContext)
        {
            _context = bookContext;
        }

        public async Task<Book?> AddBookAsync(Book book)
        {
            _context.Add(book);
            if (await SaveChangesAsync())
            {
                return book;
            }
            return null;

        }
        public void DeleteBookAsync(Guid id)
        {
            _context.Remove(id);
        }

        public async Task<Book?> GetBookAsync(Guid id)
        {
            return await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            _context.Update(book);
            return (await SaveChangesAsync());
        }

        public async Task DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            await SaveChangesAsync();
        }


        public async Task<string?> CreateBooksAsync(List<Book> books)
        {
            _context.Books.AddRange(books);
            if (await SaveChangesAsync())
            {
                return $"A list of {books.Count} was created";
            }
            return null;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
