using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publication Year is required.")]
        [Range(1000, 9999, ErrorMessage = "Enter a valid publication year.")]
        public int PublicationYear { get; set; }

        // Author
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        // Publisher
        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; } = null!;

        // Category
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}