namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            AuthorSeed.Seed(context);

            PublisherSeed.Seed(context);

            CategorySeed.Seed(context);

            BookSeed.Seed(context);

            BookCopySeed.Seed(context);

            StudentSeed.Seed(context);

            UserSeed.Seed(context);

            IssueRecordSeed.Seed(context);

            ReservationSeed.Seed(context);
        }
    }
}