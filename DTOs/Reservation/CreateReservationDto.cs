namespace LibraryManagementSystem.API.DTOs.Reservation
{
    public class CreateReservationDto
    {
        public int StudentId { get; set; }

        public int BookId { get; set; }
    }
}