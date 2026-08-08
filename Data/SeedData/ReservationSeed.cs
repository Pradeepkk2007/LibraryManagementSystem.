using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class ReservationSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Reservations.Any())
                return;

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    StudentId = 1,
                    BookId = 2,
                    ReservationDate = DateTime.UtcNow.AddDays(-2),
                    Status = "Pending"
                },

                new Reservation
                {
                    StudentId = 2,
                    BookId = 3,
                    ReservationDate = DateTime.UtcNow.AddDays(-1),
                    Status = "Pending"
                },

                new Reservation
                {
                    StudentId = 3,
                    BookId = 5,
                    ReservationDate = DateTime.UtcNow,
                    Status = "Pending"
                }
            };

            context.Reservations.AddRange(reservations);

            context.SaveChanges();
        }
    }
}