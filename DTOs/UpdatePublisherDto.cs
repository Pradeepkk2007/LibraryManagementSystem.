using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.DTOs.Publisher
{
    public class UpdatePublisherDto
    {
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
    }
}