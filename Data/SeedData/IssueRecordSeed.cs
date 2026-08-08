using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class IssueRecordSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.IssueRecords.Any())
                return;

            var issueRecords = new List<IssueRecord>
            {
                // Returned Book
                new IssueRecord
                {
                    StudentId = 1,
                    CopyId = 1,
                    IssueDate = DateTime.UtcNow.AddDays(-20),
                    DueDate = DateTime.UtcNow.AddDays(-13),
                    ReturnDate = DateTime.UtcNow.AddDays(-12),
                    Fine = 10,
                    IssuedBy = "admin",
                    ReturnedBy = "admin"
                },

                // Currently Issued
                new IssueRecord
                {
                    StudentId = 2,
                    CopyId = 2,
                    IssueDate = DateTime.UtcNow.AddDays(-4),
                    DueDate = DateTime.UtcNow.AddDays(3),
                    ReturnDate = null,
                    Fine = 0,
                    IssuedBy = "librarian"
                },

                // Overdue
                new IssueRecord
                {
                    StudentId = 3,
                    CopyId = 4,
                    IssueDate = DateTime.UtcNow.AddDays(-15),
                    DueDate = DateTime.UtcNow.AddDays(-8),
                    ReturnDate = null,
                    Fine = 80,
                    IssuedBy = "admin"
                },

                // Returned
                new IssueRecord
                {
                    StudentId = 4,
                    CopyId = 5,
                    IssueDate = DateTime.UtcNow.AddDays(-10),
                    DueDate = DateTime.UtcNow.AddDays(-3),
                    ReturnDate = DateTime.UtcNow.AddDays(-2),
                    Fine = 10,
                    IssuedBy = "librarian",
                    ReturnedBy = "librarian"
                },

                // Currently Issued
                new IssueRecord
                {
                    StudentId = 5,
                    CopyId = 7,
                    IssueDate = DateTime.UtcNow.AddDays(-2),
                    DueDate = DateTime.UtcNow.AddDays(5),
                    ReturnDate = null,
                    Fine = 0,
                    IssuedBy = "admin"
                }
            };

            context.IssueRecords.AddRange(issueRecords);

            context.SaveChanges();

            // Update BookCopy Status
            var issuedCopies = context.BookCopies
                .Where(x => issueRecords
                    .Where(i => i.ReturnDate == null)
                    .Select(i => i.CopyId)
                    .Contains(x.CopyId))
                .ToList();

            foreach (var copy in issuedCopies)
            {
                copy.Status = "Issued";
            }

            context.SaveChanges();
        }
    }
}