using LibraryManagementSystem.API.DTOs.Reservation;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDto> GetAllReservations();

        ReservationDto? GetReservationById(int reservationId);

        ReservationDto CreateReservation(CreateReservationDto dto);

        ReservationDto? CancelReservation(int reservationId);
    }
}