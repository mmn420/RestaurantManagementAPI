using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateOnly Date { get; set; }
        public string UserId { get; set; }
        public int PartySize { get; set; }
    }
}