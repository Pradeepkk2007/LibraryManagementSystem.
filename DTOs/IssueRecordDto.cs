namespace LibraryManagementSystem.API.DTOs
{
    public class IssueRecordDto
    {
        public int IssueRecordId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string BookTitle { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string PublisherName { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string Barcode { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public decimal FineAmount { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}