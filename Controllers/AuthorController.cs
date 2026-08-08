using LibraryManagementSystem.API.DTOs.Author;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();

            return Ok(authors);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpGet("{authorId}")]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _authorService.GetAuthorById(authorId);

            return Ok(author);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public IActionResult CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var message = _authorService.CreateAuthor(createAuthorDto);

            return Ok(message);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor(int authorId, UpdateAuthorDto updateAuthorDto)
        {
            var message = _authorService.UpdateAuthor(authorId, updateAuthorDto);

            return Ok(message);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            var message = _authorService.DeleteAuthor(authorId);

            return Ok(message);
        }
    }
}