using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class CategorySeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Categories.Any())
                return;

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "Programming",
                    Description = "Programming languages and software development."
                },

                new Category
                {
                    CategoryName = "Database",
                    Description = "Database systems and SQL."
                },

                new Category
                {
                    CategoryName = "Networking",
                    Description = "Computer networking and communication."
                },

                new Category
                {
                    CategoryName = "Operating System",
                    Description = "Operating systems and system programming."
                },

                new Category
                {
                    CategoryName = "Algorithms",
                    Description = "Algorithms and data structures."
                },

                new Category
                {
                    CategoryName = "Artificial Intelligence",
                    Description = "AI and Machine Learning."
                },

                new Category
                {
                    CategoryName = "Cyber Security",
                    Description = "Security, ethical hacking and cryptography."
                },

                new Category
                {
                    CategoryName = "Software Engineering",
                    Description = "Software design, testing and project management."
                },

                new Category
                {
                    CategoryName = "Cloud Computing",
                    Description = "Cloud technologies and DevOps."
                },

                new Category
                {
                    CategoryName = "Computer Science",
                    Description = "General computer science books."
                }
            };

            context.Categories.AddRange(categories);

            context.SaveChanges();
        }
    }
}