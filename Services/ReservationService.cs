using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Reservation;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ReservationDto> GetAllReservations()
        {
            var reservations = _context.Reservations
                                       .Include(x => x.Student)
                                       .Include(x => x.Book)
                                       .ToList();

            var reservationDtos = new List<ReservationDto>();

            foreach (var reservation in reservations)
            {
                reservationDtos.Add(new ReservationDto
                {
                    ReservationId = reservation.ReservationId,

                    StudentName = reservation.Student.FirstName + " " +
                                  reservation.Student.LastName,

                    BookTitle = reservation.Book.Title,

                    ReservationDate = reservation.ReservationDate,

                    Status = reservation.Status
                });
            }

            return reservationDtos;
        }

        public ReservationDto? GetReservationById(int reservationId)
        {
            var reservation = _context.Reservations
                                      .Include(x => x.Student)
                                      .Include(x => x.Book)
                                      .FirstOrDefault(x => x.ReservationId == reservationId);

            if (reservation == null)
            {
                return null;
            }

            var reservationDto = new ReservationDto
            {
                ReservationId = reservation.ReservationId,

                StudentName = reservation.Student.FirstName + " " +
                              reservation.Student.LastName,

                BookTitle = reservation.Book.Title,

                ReservationDate = reservation.ReservationDate,

                Status = reservation.Status
            };

            return reservationDto;
        }



        public ReservationDto CreateReservation(CreateReservationDto dto)
        {
            var student = _context.Students
                                  .FirstOrDefault(x => x.StudentId == dto.StudentId);

            if (student == null)
            {
                throw new NotFoundException("Student not found.");
            }

            var book = _context.Books
                               .FirstOrDefault(x => x.BookId == dto.BookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            var availableCopies = _context.BookCopies
                                          .Count(x =>
                                              x.BookId == dto.BookId &&
                                              x.Status == "Available");

            if (availableCopies > 0)
            {
                throw new BadRequestException("Book is available. Please issue it instead.");
            }

            var alreadyReserved = _context.Reservations.Any(x =>
                x.StudentId == dto.StudentId &&
                x.BookId == dto.BookId &&
                x.Status == "Pending");

            if (alreadyReserved)
            {
                throw new BadRequestException("You have already reserved this book.");
            }

            var alreadyIssued = _context.IssueRecords.Any(x =>
                x.StudentId == dto.StudentId &&
                x.BookCopy.BookId == dto.BookId &&
                x.ReturnDate == null);

            if (alreadyIssued)
            {
                throw new BadRequestException("You already have this book.");
            }

            var reservation = new Reservation
            {
                StudentId = dto.StudentId,
                BookId = dto.BookId,
                ReservationDate = DateTime.Now,
                Status = "Pending"
            };

            _context.Reservations.Add(reservation);

            _context.SaveChanges();

            return new ReservationDto
            {
                ReservationId = reservation.ReservationId,
                StudentName = student.FirstName + " " + student.LastName,
                BookTitle = book.Title,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status
            };
        }
        public ReservationDto? CancelReservation(int reservationId)
        {
            var reservation = _context.Reservations
                                      .Include(x => x.Student)
                                      .Include(x => x.Book)
                                      .FirstOrDefault(x => x.ReservationId == reservationId);

            if (reservation == null)
            {
                return null;
            }

            reservation.Status = "Cancelled";

            _context.SaveChanges();

            return new ReservationDto
            {
                ReservationId = reservation.ReservationId,

                StudentName = reservation.Student.FirstName + " " +
                              reservation.Student.LastName,

                BookTitle = reservation.Book.Title,

                ReservationDate = reservation.ReservationDate,

                Status = reservation.Status
            };
        }

    }
}

