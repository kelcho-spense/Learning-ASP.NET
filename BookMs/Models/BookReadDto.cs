using System.ComponentModel.DataAnnotations.Schema;

namespace BookMs.Models
{
    public class BookReadDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DatePublished { get; set; }
        public int AuthorId { get; set; }
    }
}
