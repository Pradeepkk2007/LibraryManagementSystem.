using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class AuthorSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Authors.Any())
                return;

            var authors = new List<Author>
            {
                new Author
                {
                    FirstName = "Robert",
                    LastName = "Martin",
                    Biography = "Author of Clean Code.",
                    Country = "USA"
                },

                new Author
                {
                    FirstName = "Andrew",
                    LastName = "Hunt",
                    Biography = "Author of The Pragmatic Programmer.",
                    Country = "USA"
                },

                new Author
                {
                    FirstName = "Erich",
                    LastName = "Gamma",
                    Biography = "Co-author of Design Patterns.",
                    Country = "Switzerland"
                },

                new Author
                {
                    FirstName = "Martin",
                    LastName = "Fowler",
                    Biography = "Software architecture expert.",
                    Country = "UK"
                },

                new Author
                {
                    FirstName = "Thomas",
                    LastName = "Cormen",
                    Biography = "Algorithms expert.",
                    Country = "USA"
                },

                new Author
                {
                    FirstName = "Eric",
                    LastName = "Matthes",
                    Biography = "Python Crash Course author.",
                    Country = "USA"
                },

                new Author
                {
                    FirstName = "Abraham",
                    LastName = "Silberschatz",
                    Biography = "Database Systems Concepts author.",
                    Country = "USA"
                },

                new Author
                {
                    FirstName = "James",
                    LastName = "Kurose",
                    Biography = "Computer Networking author.",
                    Country = "USA"
                },

                new Author
                {
                    FirstName = "Ian",
                    LastName = "Sommerville",
                    Biography = "Software Engineering author.",
                    Country = "UK"
                },

                new Author
                {
                    FirstName = "Joshua",
                    LastName = "Bloch",
                    Biography = "Effective Java author.",
                    Country = "USA"
                }
            };

            context.Authors.AddRange(authors);

            context.SaveChanges();
        }
    }
}