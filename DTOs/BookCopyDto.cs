namespace LibraryManagementSystem.API.DTOs
{
    public class BookCopyDto
    {
        public int CopyId { get; set; }
        public string BookTitle { get; set; } = string.Empty;

        public string Barcode { get; set; } = string.Empty;

        public string ShelfLocation { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
