using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookCopyController : ControllerBase
{
    private readonly IBookCopyService _bookCopyService;

    public BookCopyController(IBookCopyService bookCopyService)
    {
        _bookCopyService = bookCopyService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllBookCopies()
    {
        var bookCopies = _bookCopyService.GetAllBookCopies();

        return Ok(bookCopies);
    }

    [HttpGet("{copyId}")]
    [Authorize]
    public IActionResult GetBookCopyById(int copyId)
    {
        var bookCopy = _bookCopyService.GetBookCopyById(copyId);

        if (bookCopy == null)
        {
            return NotFound("Book copy not found.");
        }

        return Ok(bookCopy);
    }

    
    [HttpPost]
    [Authorize(Roles = "Admin,Librarian")]
    public IActionResult CreateBookCopy(CreateBookCopyDto createBookCopyDto)
    {
        var bookCopy = _bookCopyService.CreateBookCopy(createBookCopyDto);

        if (bookCopy == null)
        {
            return NotFound("Book not found.");
        }

        return Ok(bookCopy);
    }

    
    [HttpPut("{copyId}")]
    [Authorize(Roles = "Admin,Librarian")]
    public IActionResult UpdateBookCopy(int copyId, UpdateBookCopyDto updateBookCopyDto)
    {
        var bookCopy = _bookCopyService.UpdateBookCopy(copyId, updateBookCopyDto);

        if (bookCopy == null)
        {
            return NotFound("Book copy or Book not found.");
        }

        return Ok(bookCopy);
    }

    
    [HttpDelete("{copyId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteBookCopy(int copyId)
    {
        var bookCopy = _bookCopyService.DeleteBookCopy(copyId);

        if (bookCopy == null)
        {
            return NotFound("Book copy not found.");
        }

        return Ok(bookCopy);
    }
}