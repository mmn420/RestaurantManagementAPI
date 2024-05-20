using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Interfaces;
using api.Models;
using api.utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepo;

        public ReservationController(IReservationRepository reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationRepo.GetAllReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationRepo.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto reservationModel)
        {
            var dateFromString = Utilities.ParseDateInput(reservationModel.Date);
            Reservation newReservation = new Reservation
            {
                Date = dateFromString,
                TableId = reservationModel.TableId,
                UserId = reservationModel.UserId,
                PartySize = reservationModel.PartySize
            };
            bool isAvailable = await _reservationRepo.CheckAvailabilityAsync(dateFromString, newReservation.PartySize, newReservation.TableId);
            if (!isAvailable)
            {
                return BadRequest("Reservation not available");
            }
            var reservation = await _reservationRepo.CreateReservationAsync(newReservation);
            return Ok(reservation);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] CreateReservationDto reservationDto)
        {
            var reservation = await _reservationRepo.UpdateReservationAsync(id, reservationDto);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationRepo.DeleteReservationAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
    }
}