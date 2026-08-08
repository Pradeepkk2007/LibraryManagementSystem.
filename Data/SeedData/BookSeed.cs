using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class BookSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Books.Any())
                return;

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Clean Code",
                    ISBN = "9780132350884",
                    PublicationYear = 2008,
                    AuthorId = 1,
                    PublisherId = 1,
                    CategoryId = 1
                },

                new Book
                {
                    Title = "The Pragmatic Programmer",
                    ISBN = "9780201616224",
                    PublicationYear = 1999,
                    AuthorId = 2,
                    PublisherId = 2,
                    CategoryId = 1
                },

                new Book
                {
                    Title = "Design Patterns",
                    ISBN = "9780201633610",
                    PublicationYear = 1994,
                    AuthorId = 3,
                    PublisherId = 3,
                    CategoryId = 8
                },

                new Book
                {
                    Title = "Refactoring",
                    ISBN = "9780134757599",
                    PublicationYear = 2018,
                    AuthorId = 4,
                    PublisherId = 1,
                    CategoryId = 8
                },

                new Book
                {
                    Title = "Introduction to Algorithms",
                    ISBN = "9780262033848",
                    PublicationYear = 2022,
                    AuthorId = 5,
                    PublisherId = 10,
                    CategoryId = 5
                },

                new Book
                {
                    Title = "Python Crash Course",
                    ISBN = "9781593279288",
                    PublicationYear = 2019,
                    AuthorId = 6,
                    PublisherId = 9,
                    CategoryId = 1
                },

                new Book
                {
                    Title = "Database System Concepts",
                    ISBN = "9781260084504",
                    PublicationYear = 2019,
                    AuthorId = 7,
                    PublisherId = 3,
                    CategoryId = 2
                },

                new Book
                {
                    Title = "Computer Networking",
                    ISBN = "9780133594140",
                    PublicationYear = 2021,
                    AuthorId = 8,
                    PublisherId = 4,
                    CategoryId = 3
                },

                new Book
                {
                    Title = "Software Engineering",
                    ISBN = "9780137035151",
                    PublicationYear = 2015,
                    AuthorId = 9,
                    PublisherId = 4,
                    CategoryId = 8
                },

                new Book
                {
                    Title = "Effective Java",
                    ISBN = "9780134685991",
                    PublicationYear = 2018,
                    AuthorId = 10,
                    PublisherId = 8,
                    CategoryId = 1
                }
            };

            context.Books.AddRange(books);

            context.SaveChanges();
        }
    }
}