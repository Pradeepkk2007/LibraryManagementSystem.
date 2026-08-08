using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.StudentDashboard;
using LibraryManagementSystem.API.DTOs.StudentHistory;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Services
{
    public class StudentDashboardService : IStudentDashboardService
    {
        private readonly ApplicationDbContext _context;

        public StudentDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentDashboardDto GetStudentDashboard(int studentId)
        {
            // Check Student
            var student = _context.Students
                                  .FirstOrDefault(x => x.StudentId == studentId);

            if (student == null)
            {
                throw new NotFoundException("Student not found.");
            }

            // Currently Issued Books
            var currentlyIssued = _context.IssueRecords
                                          .Count(x =>
                                              x.StudentId == studentId &&
                                              x.ReturnDate == null);

            // Total Borrowed Books
            var totalBorrowed = _context.IssueRecords
                                        .Count(x =>
                                            x.StudentId == studentId);

            // Overdue Books
            var overdueBooks = _context.IssueRecords
                                       .Count(x =>
                                           x.StudentId == studentId &&
                                           x.ReturnDate == null &&
                                           x.DueDate < DateTime.Today);

            // Current Fine
            var currentFine = _context.IssueRecords
                                      .Where(x =>
                                          x.StudentId == studentId &&
                                          x.ReturnDate == null)
                                      .Sum(x => x.Fine);

            // Next Due Date
            var nextDueDate = _context.IssueRecords
                                      .Where(x =>
                                          x.StudentId == studentId &&
                                          x.ReturnDate == null)
                                      .OrderBy(x => x.DueDate)
                                      .Select(x => (DateTime?)x.DueDate)
                                      .FirstOrDefault();

            // Recent History (Last 5 Books)
            var recentHistory = _context.IssueRecords
                                        .Include(x => x.BookCopy)
                                        .ThenInclude(x => x.Book)
                                        .Where(x => x.StudentId == studentId)
                                        .OrderByDescending(x => x.IssueDate)
                                        .Take(5)
                                        .Select(x => new StudentHistoryDto
                                        {
                                            BookTitle = x.BookCopy.Book.Title,
                                            IssueDate = x.IssueDate,
                                            DueDate = x.DueDate,
                                            ReturnDate = x.ReturnDate,
                                            Fine = x.Fine,
                                            Status = x.ReturnDate == null
                                                        ? "Issued"
                                                        : "Returned"
                                        })
                                        .ToList();

            return new StudentDashboardDto
            {
                StudentId = student.StudentId,
                RollNumber = student.RollNumber,
                StudentName = student.FirstName + " " + student.LastName,
                Department = student.Department,
                Semester = student.Semester,
                CurrentlyIssuedBooks = currentlyIssued,
                TotalBorrowedBooks = totalBorrowed,
                OverdueBooks = overdueBooks,
                CurrentFine = currentFine,
                NextDueDate = nextDueDate,
                RecentHistory = recentHistory
            };
        }
    }
}