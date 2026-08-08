namespace LibraryManagementSystem.API.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int StudentId { get; set; }

        // student Navigation Property
        public Student Student { get; set; } = null!;

        public int BookId { get; set; }

        //Book Navigation Property
        public Book Book { get; set; } = null!;

        public DateTime ReservationDate { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
