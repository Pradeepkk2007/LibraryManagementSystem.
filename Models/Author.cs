using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Biography { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        // Navigation Property
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}