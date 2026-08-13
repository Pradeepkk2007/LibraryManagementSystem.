using LibraryManagementSystem.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class SeedData
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            const int maxRetries = 5;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    Console.WriteLine(
                        $"Database initialization attempt {attempt}/{maxRetries}...");

                    await context.Database.MigrateAsync();

                    Console.WriteLine(
                        "Database migration completed successfully.");

                    AuthorSeed.Seed(context);
                    PublisherSeed.Seed(context);
                    CategorySeed.Seed(context);
                    BookSeed.Seed(context);
                    BookCopySeed.Seed(context);
                    StudentSeed.Seed(context);
                    UserSeed.Seed(context);
                    IssueRecordSeed.Seed(context);
                    ReservationSeed.Seed(context);

                    Console.WriteLine(
                        "Database seed completed successfully.");

                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Database initialization failed on attempt {attempt}:");

                    Console.WriteLine(ex.Message);

                    if (attempt == maxRetries)
                    {
                        Console.WriteLine(
                            "Database initialization failed after all retry attempts.");

                        throw;
                    }

                    var delaySeconds = attempt * 10;

                    Console.WriteLine(
                        $"Retrying in {delaySeconds} seconds...");

                    await Task.Delay(
                        TimeSpan.FromSeconds(delaySeconds));
                }
            }
        }
    }
}