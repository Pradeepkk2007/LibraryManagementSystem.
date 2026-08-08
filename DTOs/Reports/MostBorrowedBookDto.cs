namespace LibraryManagementSystem.API.DTOs.Reports
{
    public class MostBorrowedBookDto
    {
        public string BookTitle { get; set; } = string.Empty;
        public int TimesBorrowed { get; set; }
    }
}
