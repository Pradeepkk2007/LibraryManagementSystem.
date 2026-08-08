namespace LibraryManagementSystem.API.DTOs.Reports
{
    public class NeverBorrowedBookDto
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}