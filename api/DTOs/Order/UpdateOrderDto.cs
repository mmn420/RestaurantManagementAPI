using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Order
{
    public class UpdateOrderDto
    {
        [Required]
        public string OrderStatus { get; set; } = string.Empty;
    }
}