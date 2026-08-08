using Azure.Core.GeoJson;
using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Reports;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading.Tasks.Dataflow;

namespace LibraryManagementSystem.API.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OverdueBookDto> GetOverdueBooks()
        {
            var records = _context.IssueRecords
                                  .Include(x => x.Student)
                                  .Include(x => x.BookCopy)
                                  .ThenInclude(x => x.Book)
                                  .Where(x =>
                                      x.ReturnDate == null &&
                                      x.DueDate < DateTime.Today)
                                  .ToList();

            var overdueBooks = new List<OverdueBookDto>();

            foreach (var record in records)
            {
                overdueBooks.Add(new OverdueBookDto
                {
                    IssueId = record.IssueId,
                    StudentName = record.Student.FirstName + " " + record.Student.LastName,
                    BookTitle = record.BookCopy.Book.Title,
                    Barcode = record.BookCopy.Barcode,
                    DueDate = record.DueDate,
                    DaysLate = (DateTime.Today - record.DueDate).Days,
                    Fine = record.Fine
                });
            }

            return overdueBooks;
        }

        public List<MostBorrowedBookDto> GetMostBorrowedBooks()
        {
            return _context.IssueRecords
               .Include(x => x.BookCopy)
               .ThenInclude(x => x.Book)
               .GroupBy(x => x.BookCopy.BookId)
               .Select(group => new MostBorrowedBookDto
               {
                   BookTitle = group.First().BookCopy.Book.Title,
                   TimesBorrowed = group.Count()
               })
               .OrderByDescending(x => x.TimesBorrowed)
               .Take(5)
               .ToList();
        }

        public List<TopReaderDto> GetTopReaders()
        {
            return _context.IssueRecords
                           .Include(x => x.Student)
                           .GroupBy(x => x.StudentId)
                           .Select(group => new TopReaderDto
                           {
                               StudentId = group.Key,
                               StudentName = group.First().Student.FirstName + " " + group.First().Student.LastName,
                               TotalBorrowed = group.Count()
                           })
                           .OrderByDescending(x => x.TotalBorrowed)
                           .Take(10)
                           .ToList();
        }
        public List<NeverBorrowedBookDto> GetNeverBorrowedBooks()
        {
            return _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(book => !book.BookCopies
                    .Any(copy => _context.IssueRecords
                        .Any(issue => issue.CopyId == copy.CopyId)))
                .Select(book => new NeverBorrowedBookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorName = book.Author.FullName,
                    CategoryName = book.Category.CategoryName
                })
                .ToList();
        }

        public List<MonthlyStatisticsDto> GetMonthlyStatistics()
        {
            return _context.IssueRecords
                            .GroupBy(x => new
                            {
                                x.IssueDate.Year,
                                x.IssueDate.Month
                            })
                            .Select(group => new MonthlyStatisticsDto
                            {
                                Year = group.Key.Year,
                                MonthNumber = group.Key.Month,
                                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month),
                                TotalBooksIssued = group.Count()
                            })
                            .OrderBy(x => x.Year)
                            .ThenBy(x => x.MonthNumber)
                            .ToList();
        }


    }

}
