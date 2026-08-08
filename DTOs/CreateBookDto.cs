using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.DTOs.Book
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publication Year is required.")]
        [Range(1000, 9999)]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
    }
}