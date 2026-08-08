namespace LibraryManagementSystem.API.DTOs.StudentHistory
{
    public class StudentHistoryDto
    {
        public string BookTitle { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal Fine { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
