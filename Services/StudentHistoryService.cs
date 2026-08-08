using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.StudentHistory;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Services
{
    public class StudentHistoryService : IStudentHistoryService
    {
        private readonly ApplicationDbContext _context;

        public StudentHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<StudentHistoryDto> GetStudentHistory(int studentId)
        {
            var student = _context.Students
                                  .FirstOrDefault(x => x.StudentId == studentId);

            if(student == null)
            {
                throw new NotFoundException("Student not found.");
            }

            var issueRecords = _context.IssueRecords
                                       .Include(x => x.BookCopy)
                                       .ThenInclude(x => x.Book)
                                       .Where(x => x.StudentId == studentId)
                                       .OrderByDescending(x => x.IssueDate)
                                       .ToList();
            var history = new List<StudentHistoryDto>();

            foreach(var record in issueRecords)
            {
                history.Add(new StudentHistoryDto
                {
                    BookTitle  = record.BookCopy.Book.Title,
                    IssueDate = record.IssueDate,
                    DueDate = record.DueDate,
                    ReturnDate = record.ReturnDate,
                    Fine = record.Fine,
                    Status = record.ReturnDate == null ? "Issued" : "Returned"
                });
            }

            return history;
        }
    }
}
