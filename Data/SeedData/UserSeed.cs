using BCrypt.Net;
using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class UserSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any())
                return;

            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Email = "admin@lms.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new User
                {
                    Username = "librarian",
                    Email = "librarian@lms.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Librarian@123"),
                    Role = "Librarian",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new User
                {
                    Username = "student",
                    Email = "student@lms.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Student@123"),
                    Role = "Student",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }
    }
}