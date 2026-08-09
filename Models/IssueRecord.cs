using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.API.Models
{
    public class IssueRecord
    {
        [Key]
        public int IssueId { get; set; }

        public int StudentId { get; set; }

        public int CopyId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fine { get; set; }

        public string IssuedBy { get; set; } = string.Empty;

        public string ReturnedBy { get; set; } = string.Empty;

        // Navigation Properties
        public Student Student { get; set; } = null!;

        public BookCopy BookCopy { get; set; } = null!;
    }
}