using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.DTOs
{
    public class CreateIssueRecordDto
    {
        [Range(1, int.MaxValue,
            ErrorMessage = "Please select a valid Student.")]
        public int StudentId { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Please select a valid Book Copy.")]
        public int CopyId { get; set; }

        [Required(ErrorMessage = "Issued By is required.")]
        [StringLength(100)]
        public string IssuedBy { get; set; } = string.Empty;
    }
}