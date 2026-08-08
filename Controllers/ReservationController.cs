using LibraryManagementSystem.API.DTOs.Reservation;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin,Librarian")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllReservations()
        {
            return Ok(_reservationService.GetAllReservations());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetReservationById(int id)
        {
            var reservation = _reservationService.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult CreateReservation(CreateReservationDto dto)
        {
            var reservation = _reservationService.CreateReservation(dto);

            return Ok(reservation);
        }

        [HttpPut("Cancel/{id}")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult CancelReservation(int id)
        {
            var reservation = _reservationService.CancelReservation(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }
    }
}