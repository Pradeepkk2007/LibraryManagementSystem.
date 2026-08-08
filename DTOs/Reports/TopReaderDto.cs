namespace LibraryManagementSystem.API.DTOs.Reports
{
    public class TopReaderDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int TotalBorrowed { get; set; }
    }
}
