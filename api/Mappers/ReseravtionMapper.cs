using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Reservation;
using api.Models;

namespace api.Mappers
{
    public static class ReseravtionMapper
    {
        public static ReservationDto ToReservationDto(this Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                Date = reservation.Date,
                TableId = reservation.TableId,
                UserId = reservation.UserId,
                PartySize = reservation.PartySize
            };
        }
    }
}