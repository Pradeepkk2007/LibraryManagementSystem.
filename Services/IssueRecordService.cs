using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Services
{
    public class IssueRecordService : IIssueRecordService
    {
        private readonly ApplicationDbContext _context;

        public IssueRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<IssueRecordDto> GetAllIssueRecords()
        {
            var issueRecords = _context.IssueRecords
                .Include(i => i.Student)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Publisher)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Category)
                .ToList();

            var issueRecordDtos = new List<IssueRecordDto>();

            foreach (var issueRecord in issueRecords)
            {
                issueRecordDtos.Add(new IssueRecordDto
                {
                    IssueRecordId = issueRecord.IssueId,
                    StudentName = issueRecord.Student.FirstName + " " + issueRecord.Student.LastName,
                    BookTitle = issueRecord.BookCopy.Book.Title,
                    AuthorName = issueRecord.BookCopy.Book.Author.FullName,
                    PublisherName = issueRecord.BookCopy.Book.Publisher.PublisherName,
                    CategoryName = issueRecord.BookCopy.Book.Category.CategoryName,
                    Barcode = issueRecord.BookCopy.Barcode,
                    IssueDate = issueRecord.IssueDate,
                    DueDate = issueRecord.DueDate,
                    ReturnDate = issueRecord.ReturnDate,
                    FineAmount = issueRecord.Fine,
                    Status = issueRecord.BookCopy.Status
                });
            }

            return issueRecordDtos;
        }

        public IssueRecordDto? GetIssueRecordById(int issueId)
        {
            var issueRecord = _context.IssueRecords
                .Include(i => i.Student)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Publisher)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Category)
                .FirstOrDefault(i => i.IssueId == issueId);

            if (issueRecord == null)
            {
                return null;
            }

            return new IssueRecordDto
            {
                IssueRecordId = issueRecord.IssueId,
                StudentName = issueRecord.Student.FirstName + " " + issueRecord.Student.LastName,
                BookTitle = issueRecord.BookCopy.Book.Title,
                AuthorName = issueRecord.BookCopy.Book.Author.FullName,
                PublisherName = issueRecord.BookCopy.Book.Publisher.PublisherName,
                CategoryName = issueRecord.BookCopy.Book.Category.CategoryName,
                Barcode = issueRecord.BookCopy.Barcode,
                IssueDate = issueRecord.IssueDate,
                DueDate = issueRecord.DueDate,
                ReturnDate = issueRecord.ReturnDate,
                FineAmount = issueRecord.Fine,
                Status = issueRecord.BookCopy.Status
            };
        }

        public IssueRecordDto? IssueBook(CreateIssueRecordDto createIssueRecordDto)
        {
            var student = _context.Students.Find(createIssueRecordDto.StudentId);

            if (student == null)
            {
                return null;
            }

            var bookCopy = _context.BookCopies
                .Include(bc => bc.Book)
                    .ThenInclude(b => b.Author)
                .Include(bc => bc.Book)
                    .ThenInclude(b => b.Publisher)
                .Include(bc => bc.Book)
                    .ThenInclude(b => b.Category)
                .FirstOrDefault(bc => bc.CopyId == createIssueRecordDto.CopyId);

            if (bookCopy == null)
            {
                return null;
            }

            if (bookCopy.Status != "Available")
            {
                return null;
            }

            var issueRecord = new IssueRecord
            {
                StudentId = createIssueRecordDto.StudentId,
                CopyId = createIssueRecordDto.CopyId,
                IssueDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(7),
                ReturnDate = null,
                Fine = 0,
                IssuedBy = createIssueRecordDto.IssuedBy
            };

            bookCopy.Status = "Issued";

            _context.IssueRecords.Add(issueRecord);

            _context.SaveChanges();

            return new IssueRecordDto
            {
                IssueRecordId = issueRecord.IssueId,
                StudentName = student.FirstName + " " + student.LastName,
                BookTitle = bookCopy.Book.Title,
                AuthorName = bookCopy.Book.Author.FullName,
                PublisherName = bookCopy.Book.Publisher.PublisherName,
                CategoryName = bookCopy.Book.Category.CategoryName,
                Barcode = bookCopy.Barcode,
                IssueDate = issueRecord.IssueDate,
                DueDate = issueRecord.DueDate,
                ReturnDate = issueRecord.ReturnDate,
                FineAmount = issueRecord.Fine,
                Status = bookCopy.Status
            };
        }

        public IssueRecordDto? ReturnBook(int issueId, UpdateIssueRecordDto updateIssueRecordDto)
        {
            var issueRecord = _context.IssueRecords
                .Include(i => i.Student)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Publisher)
                .Include(i => i.BookCopy)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Category)
                .FirstOrDefault(i => i.IssueId == issueId);

            if (issueRecord == null)
            {
                return null;
            }

            if (issueRecord.ReturnDate != null)
            {
                return null;
            }

            issueRecord.ReturnDate = DateTime.UtcNow;

            if (issueRecord.ReturnDate > issueRecord.DueDate)
            {
                var lateDays = (issueRecord.ReturnDate.Value - issueRecord.DueDate).Days;
                issueRecord.Fine = lateDays * 10;
            }
            else
            {
                issueRecord.Fine = 0;
            }

            issueRecord.ReturnedBy = updateIssueRecordDto.ReturnedBy;

            issueRecord.BookCopy.Status = "Available";

            _context.SaveChanges();

            return new IssueRecordDto
            {
                IssueRecordId = issueRecord.IssueId,
                StudentName = issueRecord.Student.FirstName + " " + issueRecord.Student.LastName,
                BookTitle = issueRecord.BookCopy.Book.Title,
                AuthorName = issueRecord.BookCopy.Book.Author.FullName,
                PublisherName = issueRecord.BookCopy.Book.Publisher.PublisherName,
                CategoryName = issueRecord.BookCopy.Book.Category.CategoryName,
                Barcode = issueRecord.BookCopy.Barcode,
                IssueDate = issueRecord.IssueDate,
                DueDate = issueRecord.DueDate,
                ReturnDate = issueRecord.ReturnDate,
                FineAmount = issueRecord.Fine,
                Status = issueRecord.BookCopy.Status
            };
        }
    }
}