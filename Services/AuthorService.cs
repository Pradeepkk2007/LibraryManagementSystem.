using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Author;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            return _context.Authors
                           .Select(author => new AuthorDto
                           {
                               AuthorId = author.AuthorId,
                               FullName = author.FullName,
                               Biography = author.Biography,
                               Country = author.Country
                           })
                           .ToList();
        }

        public AuthorDto GetAuthorById(int authorId)
        {
            var author = _context.Authors
                                 .FirstOrDefault(x => x.AuthorId == authorId);

            if (author == null)
            {
                throw new NotFoundException("Author not found.");
            }

            return new AuthorDto
            {
                AuthorId = author.AuthorId,
                FullName = author.FullName,
                Biography = author.Biography,
                Country = author.Country
            };
        }

        public string CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            bool authorExists = _context.Authors.Any(x =>
                x.FirstName == createAuthorDto.FirstName &&
                x.LastName == createAuthorDto.LastName);

            if (authorExists)
            {
                throw new BadRequestException("Author already exists.");
            }

            var author = new Author
            {
                FirstName = createAuthorDto.FirstName,
                LastName = createAuthorDto.LastName,
                Biography = createAuthorDto.Biography,
                Country = createAuthorDto.Country,
                CreatedAt = DateTime.UtcNow
            };

            _context.Authors.Add(author);

            _context.SaveChanges();

            return "Author created successfully.";
        }

        public string UpdateAuthor(int authorId, UpdateAuthorDto updateAuthorDto)
        {
            var author = _context.Authors
                                 .FirstOrDefault(x => x.AuthorId == authorId);

            if (author == null)
            {
                throw new NotFoundException("Author not found.");
            }

            author.FirstName = updateAuthorDto.FirstName;
            author.LastName = updateAuthorDto.LastName;
            author.Biography = updateAuthorDto.Biography;
            author.Country = updateAuthorDto.Country;
            author.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return "Author updated successfully.";
        }

        public string DeleteAuthor(int authorId)
        {
            var author = _context.Authors
                                 .FirstOrDefault(x => x.AuthorId == authorId);

            if (author == null)
            {
                throw new NotFoundException("Author not found.");
            }

            _context.Authors.Remove(author);

            _context.SaveChanges();

            return "Author deleted successfully.";
        }
    }
}