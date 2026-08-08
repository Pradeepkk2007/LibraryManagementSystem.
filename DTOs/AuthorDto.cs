namespace LibraryManagementSystem.API.DTOs.Author
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? Biography { get; set; }

        public string Country { get; set; } = string.Empty;
    }
}