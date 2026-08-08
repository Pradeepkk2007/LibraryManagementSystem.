using LibraryManagementSystem.API.DTOs.Book;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Book
        /// <summary>
        /// Retrieves all books with optional search, filtering and pagination.
        /// </summary>
        /// <returns>List of books.</returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<BookDto>> GetAllBooks([FromQuery] BookQueryDto query)
        {
            var books = _bookService.GetAllBooks(query);

            return Ok(books);
        }

        // GET: api/Book/5
        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <returns>Book details.</returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public IActionResult GetBookById(int bookId)
        {
            var book = _bookService.GetBookById(bookId);

            return Ok(book);
        }

        // POST: api/Book
        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="createBookDto">Book information.</param>
        /// <returns>Success message.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateBook(CreateBookDto createBookDto)
        {
            var message = _bookService.CreateBook(createBookDto);

            return Ok(message);
        }

        // PUT: api/Book/5
        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <param name="updateBookDto">Updated book details.</param>
        /// <returns>Success message.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Librarian")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateBook(int bookId, UpdateBookDto updateBookDto)
        {
            var message = _bookService.UpdateBook(bookId, updateBookDto);

            return Ok(message);
        }

        // DELETE: api/Book/5
        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <returns>Success message.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(int bookId)
        {
            var message = _bookService.DeleteBook(bookId);

            return Ok(message);
        }
    }
}