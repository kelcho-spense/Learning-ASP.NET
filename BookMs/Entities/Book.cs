using System.ComponentModel.DataAnnotations.Schema;

namespace BookMs.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DatePublished { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
