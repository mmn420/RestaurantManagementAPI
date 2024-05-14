using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;

namespace api.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation?> GetReservationByIdAsync(int id);
        Task<Reservation?> CreateReservationAsync(Reservation reservation);
        Task<Reservation?> UpdateReservationAsync(int id, CreateReservationDto reservationDto);
        Task<Reservation?> DeleteReservationAsync(int id);
        Task<bool> CheckAvailabilityAsync(DateOnly date, int partySize, int tableId);
    }
}