using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.DTOs
{
    public class UpdateIssueRecordDto
    {
        [Required(ErrorMessage = "Returned By is required.")]
        [StringLength(100)]
        public string ReturnedBy { get; set; } = string.Empty;
    }
}