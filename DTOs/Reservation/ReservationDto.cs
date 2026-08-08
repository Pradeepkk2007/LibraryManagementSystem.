namespace LibraryManagementSystem.API.DTOs.Reservation
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string BookTitle { get; set; } = string.Empty;

        public DateTime ReservationDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}