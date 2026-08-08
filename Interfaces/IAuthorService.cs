using LibraryManagementSystem.API.DTOs.Author;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAllAuthors();

        AuthorDto GetAuthorById(int authorId);

        string CreateAuthor(CreateAuthorDto createAuthorDto);

        string UpdateAuthor(int authorId, UpdateAuthorDto updateAuthorDto);

        string DeleteAuthor(int authorId);
    }
}