using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin, Librarian")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("OverdueBooks")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult GetOverdueBooks()
        {
            var result = _reportService.GetOverdueBooks();
            return Ok(result);
        }

        [HttpGet("MostBorrowedBooks")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult GetMostBorrowedBooks()
        {
            var result = _reportService.GetMostBorrowedBooks();
            return Ok(result);
        }

        [HttpGet("TopReader")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult GetTopReaders()
        {
            var result = _reportService.GetTopReaders();
            return Ok(result);
        }

        [HttpGet("NeverBorrowedBooks")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult GetNeverBorrowedBooks()
        {
            return Ok(_reportService.GetNeverBorrowedBooks());
        }

        [HttpGet("MonthlyStatistics")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult GetMonthlyStatistics()
        {
            var result = _reportService.GetMonthlyStatistics();
            return Ok(result);
        }


    }
}
