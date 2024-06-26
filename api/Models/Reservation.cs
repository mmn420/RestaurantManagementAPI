using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateOnly Date { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int PartySize { get; set; }
    }
}