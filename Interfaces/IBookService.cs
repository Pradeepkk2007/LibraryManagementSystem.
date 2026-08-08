using LibraryManagementSystem.API.DTOs.Book;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAllBooks(BookQueryDto query);

        BookDto GetBookById(int bookId);

        string CreateBook(CreateBookDto createBookDto);

        string UpdateBook(int bookId, UpdateBookDto updateBookDto);

        string DeleteBook(int bookId);
    }
}