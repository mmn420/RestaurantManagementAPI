using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.OrderItem;

namespace api.DTOs.Order
{
    public class CreateOrderDto
    {
        [Required]
        public string OrderStatus { get; set; } = string.Empty;
        [Required]
        public int TableId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public List<OrderItemsDto> orderItemsList {get; set;} = new List<OrderItemsDto>();
    }
}