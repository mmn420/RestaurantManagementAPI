using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class CreateReservationDto
    {
        [Required]
        public int TableId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PartySize { get; set; }
    }
}