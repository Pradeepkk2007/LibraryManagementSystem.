using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Dashboard;
using LibraryManagementSystem.API.Interfaces;

namespace LibraryManagementSystem.API.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public DashboardDto GetDashboard()
        {
            var totalBooks = _context.Books.Count();

            var totalBookCopies = _context.BookCopies.Count();

            var availableCopies = _context.BookCopies
                                          .Count(x => x.Status == "Available");

            var issuedCopies = _context.BookCopies
                                       .Count(x => x.Status == "Issued");

            var damagedCopies = _context.BookCopies
                                        .Count(x => x.Status == "Damaged");

            var totalStudents = _context.Students.Count();

            var booksIssuedToday = _context.IssueRecords
                                           .Count(x => x.IssueDate.Date == DateTime.Today);

            var booksReturnedToday = _context.IssueRecords
                                             .Count(x => x.ReturnDate.HasValue &&
                                                         x.ReturnDate.Value.Date == DateTime.Today);

            var totalFineCollected = _context.IssueRecords
                                             .Sum(x => x.Fine);

            return new DashboardDto
            {
                TotalBooks = totalBooks,
                TotalBookCopies = totalBookCopies,
                AvailableCopies = availableCopies,
                IssuedCopies = issuedCopies,
                DamagedCopies = damagedCopies,
                TotalStudents = totalStudents,
                BooksIssuedToday = booksIssuedToday,
                BooksReturnedToday = booksReturnedToday,
                TotalFineCollected = totalFineCollected
            };
        }
    }
}