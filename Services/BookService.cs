using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Book;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BookDto> GetAllBooks(BookQueryDto query)
        {
            var books = _context.Books
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                books = books.Where(x =>
                    x.Title.Contains(query.Search));
            }

            // Filter by Author
            if (query.AuthorId.HasValue)
            {
                books = books.Where(x =>
                    x.AuthorId == query.AuthorId);
            }

            // Filter by Publisher
            if (query.PublisherId.HasValue)
            {
                books = books.Where(x =>
                    x.PublisherId == query.PublisherId);
            }

            // Filter by Category
            if (query.CategoryId.HasValue)
            {
                books = books.Where(x =>
                    x.CategoryId == query.CategoryId);
            }

            // Pagination
            books = books
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize);

            return books
                .Select(book => new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    ISBN = book.ISBN,
                    PublicationYear = book.PublicationYear,

                    AuthorId = book.AuthorId,
                    AuthorName = book.Author.FullName,

                    PublisherId = book.PublisherId,
                    PublisherName = book.Publisher.PublisherName,

                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.CategoryName
                })
                .ToList();
        }

        public BookDto GetBookById(int bookId)
        {
            var book = _context.Books
                               .Include(x => x.Author)
                               .Include(x => x.Publisher)
                               .Include(x => x.Category)
                               .FirstOrDefault(x => x.BookId == bookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,

                AuthorId = book.AuthorId,
                AuthorName = book.Author.FirstName + " " + book.Author.LastName,

                PublisherId = book.PublisherId,
                PublisherName = book.Publisher.PublisherName,

                CategoryId = book.CategoryId,
                CategoryName = book.Category.CategoryName
            };
        }

        public string CreateBook(CreateBookDto createBookDto)
        {
            bool isbnExists = _context.Books
                                      .Any(x => x.ISBN == createBookDto.ISBN);

            if (isbnExists)
            {
                throw new BadRequestException("Book with this ISBN already exists.");
            }

            var book = new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                PublicationYear = createBookDto.PublicationYear,

                AuthorId = createBookDto.AuthorId,
                PublisherId = createBookDto.PublisherId,
                CategoryId = createBookDto.CategoryId
            };

            _context.Books.Add(book);

            _context.SaveChanges();

            return "Book created successfully.";
        }

        public string UpdateBook(int bookId, UpdateBookDto updateBookDto)
        {
            var book = _context.Books
                               .FirstOrDefault(x => x.BookId == bookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            book.Title = updateBookDto.Title;
            book.ISBN = updateBookDto.ISBN;
            book.PublicationYear = updateBookDto.PublicationYear;

            book.AuthorId = updateBookDto.AuthorId;
            book.PublisherId = updateBookDto.PublisherId;
            book.CategoryId = updateBookDto.CategoryId;

            _context.SaveChanges();

            return "Book updated successfully.";
        }

        public string DeleteBook(int bookId)
        {
            var book = _context.Books
                               .FirstOrDefault(x => x.BookId == bookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            _context.Books.Remove(book);

            _context.SaveChanges();

            return "Book deleted successfully.";
        }
    }
}