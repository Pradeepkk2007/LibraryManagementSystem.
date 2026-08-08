using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class BookCopySeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.BookCopies.Any())
                return;

            var bookCopies = new List<BookCopy>();

            int barcode = 1001;

            for (int bookId = 1; bookId <= 10; bookId++)
            {
                for (int copy = 1; copy <= 3; copy++)
                {
                    bookCopies.Add(new BookCopy
                    {
                        BookId = bookId,
                        Barcode = $"BC{barcode++}",
                        Status = "Available"
                    });
                }
            }

            context.BookCopies.AddRange(bookCopies);

            context.SaveChanges();
        }
    }
}