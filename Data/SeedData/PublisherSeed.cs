using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class PublisherSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Publishers.Any())
                return;

            var publishers = new List<Publisher>
            {
                new Publisher
                {
                    PublisherName = "Prentice Hall",
                    Address = "New Jersey, USA",
                    Phone = "+1-201-555-1001",
                    Email = "info@prenticehall.com",
                    Website = "https://www.pearson.com"
                },

                new Publisher
                {
                    PublisherName = "O'Reilly Media",
                    Address = "California, USA",
                    Phone = "+1-707-555-1002",
                    Email = "info@oreilly.com",
                    Website = "https://www.oreilly.com"
                },

                new Publisher
                {
                    PublisherName = "McGraw-Hill",
                    Address = "New York, USA",
                    Phone = "+1-212-555-1003",
                    Email = "info@mcgrawhill.com",
                    Website = "https://www.mheducation.com"
                },

                new Publisher
                {
                    PublisherName = "Pearson Education",
                    Address = "London, UK",
                    Phone = "+44-20-5555-1004",
                    Email = "info@pearson.com",
                    Website = "https://www.pearson.com"
                },

                new Publisher
                {
                    PublisherName = "Packt Publishing",
                    Address = "Birmingham, UK",
                    Phone = "+44-121-555-1005",
                    Email = "info@packt.com",
                    Website = "https://www.packtpub.com"
                },

                new Publisher
                {
                    PublisherName = "Wiley",
                    Address = "New Jersey, USA",
                    Phone = "+1-201-555-1006",
                    Email = "info@wiley.com",
                    Website = "https://www.wiley.com"
                },

                new Publisher
                {
                    PublisherName = "Springer",
                    Address = "Berlin, Germany",
                    Phone = "+49-30-555-1007",
                    Email = "info@springer.com",
                    Website = "https://www.springer.com"
                },

                new Publisher
                {
                    PublisherName = "Apress",
                    Address = "New York, USA",
                    Phone = "+1-212-555-1008",
                    Email = "info@apress.com",
                    Website = "https://www.apress.com"
                },

                new Publisher
                {
                    PublisherName = "No Starch Press",
                    Address = "California, USA",
                    Phone = "+1-415-555-1009",
                    Email = "info@nostarch.com",
                    Website = "https://nostarch.com"
                },

                new Publisher
                {
                    PublisherName = "Cambridge University Press",
                    Address = "Cambridge, UK",
                    Phone = "+44-1223-555-1010",
                    Email = "info@cambridge.org",
                    Website = "https://www.cambridge.org"
                }
            };

            context.Publishers.AddRange(publishers);

            context.SaveChanges();
        }
    }
}