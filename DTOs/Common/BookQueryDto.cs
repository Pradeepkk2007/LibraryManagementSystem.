namespace LibraryManagementSystem.API.DTOs.Book
{
    public class BookQueryDto
    {
        public string? Search { get; set; }

        public int? AuthorId { get; set; }

        public int? PublisherId { get; set; }

        public int? CategoryId { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}