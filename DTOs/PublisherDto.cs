namespace LibraryManagementSystem.API.DTOs.Publisher
{
    public class PublisherDto
    {
        public int PublisherId { get; set; }

        public string PublisherName { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }
    }
}