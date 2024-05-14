using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Interfaces;
using api.Models;
using api.utils;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDBContext _context;

        public ReservationRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckAvailabilityAsync(DateOnly date, int partySize, int tableId)
        {
            var table = _context.Tables.FirstOrDefault(x => x.Id == tableId);
            if (table == null)
            {
                return false;
            }
            else if (table.Capacity < partySize)
            {
                return false;
            }
            else if(date <= DateOnly.FromDateTime(DateTime.Now))
            {
                return false;
            }
            else
            {

                var isAvailable = await _context.Reservations.AnyAsync(x => x.TableId == tableId && x.Date == date);
                return !isAvailable;
            }
        }

        public async Task<Reservation?> CreateReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation?> DeleteReservationAsync(int id)
        {
            var existingReservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (existingReservation == null)
            {
                return null;
            }
            else
            {
                _context.Reservations.Remove(existingReservation);
                await _context.SaveChangesAsync();
                return existingReservation;
            }
        }

        public Task<List<Reservation>> GetAllReservationsAsync()
        {
            return _context.Reservations.ToListAsync();
        }

        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (reservation == null)
            {
                return null;
            }
            else
            {
                return reservation;
            }
        }

        public async Task<Reservation?> UpdateReservationAsync(int id, CreateReservationDto reservationDto)
        {
            var dateFromString = Utilities.ParseDateInput(reservationDto.Date);
            var existingReservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (existingReservation == null)
            {
                return null;
            }
            if(await CheckAvailabilityAsync(dateFromString, reservationDto.PartySize, reservationDto.TableId) == false)
            {
                return null;
            }
            else
            {
                existingReservation.Date = dateFromString;
                existingReservation.TableId = reservationDto.TableId;
                existingReservation.UserId = reservationDto.UserId;
                existingReservation.PartySize = reservationDto.PartySize;
                await _context.SaveChangesAsync();
                return existingReservation;
            }
        }
    }
}