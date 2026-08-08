namespace LibraryManagementSystem.API.DTOs.Reports
{
    public class OverdueBookDto
    {
        public int IssueId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }
        public int DaysLate { get; set; }
        public decimal Fine { get; set; }
    }
}
