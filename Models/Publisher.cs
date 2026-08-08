using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Publisher name is required.")]
        [StringLength(100)]
        public string PublisherName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Address { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Url]
        public string? Website { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation Property
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}