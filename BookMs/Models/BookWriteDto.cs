using System.ComponentModel.DataAnnotations.Schema;

namespace BookMs.Models
{
    public class BookWriteDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DatePublished { get; set; }
        public Guid AuthorId { get; set; }
    }
}
