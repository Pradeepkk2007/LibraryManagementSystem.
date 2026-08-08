using LibraryManagementSystem.API.DTOs;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IBookCopyService
    {
        List<BookCopyDto> GetAllBookCopies();

        BookCopyDto? CreateBookCopy(CreateBookCopyDto createBookCopyDto);

        BookCopyDto? GetBookCopyById(int copyId);

        BookCopyDto? UpdateBookCopy(int copyId, UpdateBookCopyDto updateBookCopyDto);

        BookCopyDto? DeleteBookCopy(int copyId);
    }
}
