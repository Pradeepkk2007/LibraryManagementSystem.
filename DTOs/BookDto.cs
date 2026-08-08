namespace LibraryManagementSystem.API.DTOs.Book
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public int PublisherId { get; set; }

        public string PublisherName { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}