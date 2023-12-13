using AutoMapper;
using BookMs.Entities;
using BookMs.Models;
using BookMs.Services.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMs.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookService _book;
        private readonly IMapper _mapper;
        public BookController(IBookService book, IMapper mapper)
        {
            _book = book;
            _mapper = mapper;
        }
        // GET: api/book
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
           var books  = await _book.GetBooksAsync();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _book.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(BookWriteDto book)
        {
            var bookReadyForCreation = _mapper.Map<Book>(book);

            var newbook = await _book.AddBookAsync(bookReadyForCreation);
            if (newbook == null)
            {
                return NotFound();
            }
            return Ok(newbook);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, BookWriteDto book)
        {
            var bookToUpdate = await _book.GetBookAsync(id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            var BookReadyForUpdating = _mapper.Map<Book>(book);
            await _book.UpdateBookAsync(bookToUpdate);           
            return NoContent();        
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            //check if book exists  
           var bookToDelete = await _book.GetBookAsync(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            await _book.DeleteBookAsync(bookToDelete);
            return NoContent();
        }
        [HttpPost("createbooks")]
        public async Task<ActionResult> CreateBooks(List<BookWriteDto> books)
        {
            var booksReadyForCreation = _mapper.Map<List<Book>>(books);
            var newbooks = await _book.CreateBooksAsync(booksReadyForCreation);
            if (newbooks == null)
            {
                return Conflict();
            }
            return Ok(newbooks);
        }   
    }
}
