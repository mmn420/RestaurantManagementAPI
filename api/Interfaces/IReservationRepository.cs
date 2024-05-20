using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.DTOs.Reservation;
using api.Models;

namespace api.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto?> GetReservationByIdAsync(int id);
        Task<ReservationDto?> CreateReservationAsync(Reservation reservation);
        Task<ReservationDto?> UpdateReservationAsync(int id, CreateReservationDto reservationDto);
        Task<ReservationDto?> DeleteReservationAsync(int id);
        Task<bool> CheckAvailabilityAsync(DateOnly date, int partySize, int tableId);
    }
}