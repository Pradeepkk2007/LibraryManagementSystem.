using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.DTOs.Author
{
    public class UpdateAuthorDto
    {
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
    }
}