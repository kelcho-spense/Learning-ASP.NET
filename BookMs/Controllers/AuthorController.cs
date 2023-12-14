using AutoMapper;
using BookMs.Entities;
using BookMs.Models;
using BookMs.Services;
using BookMs.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookMs.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService,IMapper mapper )
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorService.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorAsync(Guid id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author is null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author?>> CreateAuthorAsync(AuthorWriteDto author)
        {
            var authorToBeCreated = _mapper.Map<Author>(author);
            var createdAuthor = await _authorService.CreateAuthorAsync(authorToBeCreated);
            if (createdAuthor is null)
            {
                return NotFound();
            }
            return createdAuthor;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAuthorAsync(Author author)
        {
            //check if the author exists
            if (await _authorService.GetAuthorAsync(author.Id) is null)
            {
                return NotFound();
            }
            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthorAsync(Guid id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            if (author is null)
            {
                return NotFound();
            }
            await _authorService.DeleteAuthorAsync(author);
            return NoContent();
        }   
    }
}
