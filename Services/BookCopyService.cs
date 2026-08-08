using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.API.Services;

public class BookCopyService : IBookCopyService
{
    private readonly ApplicationDbContext _context;
    public BookCopyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<BookCopyDto> GetAllBookCopies()
    {
        var bookCopies = _context.BookCopies
                                 .Include(x => x.Book)
                                 .ToList();

        var bookCopyDtos = new List<BookCopyDto>();

        foreach (var bookCopy in bookCopies)
        {
            bookCopyDtos.Add(new BookCopyDto
            {
                CopyId = bookCopy.CopyId,
                BookTitle = bookCopy.Book.Title,
                Barcode = bookCopy.Barcode,
                ShelfLocation = bookCopy.ShelfLocation,
                Status = bookCopy.Status
            });
        }
        return bookCopyDtos;
    }

    public BookCopyDto? CreateBookCopy(CreateBookCopyDto createBookCopyDto)
    {
        // Check if book exists or not
        var book = _context.Books.Find(createBookCopyDto.BookId);

        if (book == null)
        {
            return null;
        }

        // create a new book copy
        var bookCopy = new BookCopy
        {
            BookId = createBookCopyDto.BookId,
            Barcode = createBookCopyDto.Barcode,
            ShelfLocation = createBookCopyDto.ShelfLocation,
            PurchaseDate = createBookCopyDto.PurchaseDate,
            Price = createBookCopyDto.Price,

            // Business Rule => bcz developer dicide himself
            Status = "Available"
        };



        // add to database
        _context.BookCopies.Add(bookCopy);

        // save to SQL Server
        _context.SaveChanges();

        // Return DTO
        return new BookCopyDto
        {
            CopyId = bookCopy.CopyId,
            BookTitle = book.Title,
            Barcode = bookCopy.Barcode,
            ShelfLocation = bookCopy.ShelfLocation,
            Status = bookCopy.Status
        };
    }

    public BookCopyDto? GetBookCopyById(int copyId)
    {
        var bookCopy = _context.BookCopies
                                .Include(x => x.Book)
                                .FirstOrDefault(x => x.CopyId == copyId); //"Pehla aisa record do jiska CopyId 2 ho. Agar na mile to null de do."

        if (bookCopy == null)
        {
            return null;
        }

        return new BookCopyDto
        {
            CopyId = bookCopy.CopyId,
            BookTitle = bookCopy.Book.Title,
            Barcode = bookCopy.Barcode,
            ShelfLocation = bookCopy.ShelfLocation,
            Status = bookCopy.Status
        };
    }

    public BookCopyDto? UpdateBookCopy(int copyId, UpdateBookCopyDto updateBookCopyDto)
    {
        var bookCopy = _context.BookCopies
                                .Include(x => x.Book)
                                .FirstOrDefault(x => x.CopyId == copyId);

        if (bookCopy == null)
        {
            return null;
        }
        var book = _context.Books.Find(updateBookCopyDto.BookId);

        if (book == null)
        {
            return null;
        }

        bookCopy.BookId = updateBookCopyDto.BookId;
        bookCopy.Barcode = updateBookCopyDto.Barcode;
        bookCopy.ShelfLocation = updateBookCopyDto.ShelfLocation;
        bookCopy.PurchaseDate = updateBookCopyDto.PurchaseDate;
        bookCopy.Price = updateBookCopyDto.Price;
        bookCopy.Status = updateBookCopyDto.Status;

        _context.SaveChanges();

        return new BookCopyDto
        {
            CopyId = bookCopy.CopyId,
            BookTitle = book.Title,
            Barcode = bookCopy.Barcode,
            ShelfLocation = bookCopy.ShelfLocation,
            Status = bookCopy.Status
        };


    }

    public BookCopyDto? DeleteBookCopy(int copyId)
    {
        var bookCopy = _context.BookCopies
                               .Include(x => x.Book)
                               .FirstOrDefault(x => x.CopyId == copyId);

        if (bookCopy == null)
        {
            return null;
        }

        var bookCopyDto = new BookCopyDto
        {
            CopyId = bookCopy.CopyId,
            BookTitle = bookCopy.Book.Title,
            Barcode = bookCopy.Barcode,
            ShelfLocation = bookCopy.ShelfLocation,
            Status = bookCopy.Status
        };

        _context.BookCopies.Remove(bookCopy);

        _context.SaveChanges();

        return bookCopyDto;
    }
}

