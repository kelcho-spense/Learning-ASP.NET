using BookMs.Entities;

namespace BookMs.Models
{
    public class AuthorReadDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Book>? Books { get; set; }
    }
}
