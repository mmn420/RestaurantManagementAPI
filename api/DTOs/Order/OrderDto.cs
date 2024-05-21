using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.OrderItem;
using api.Models;

namespace api.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public int TableId { get; set; }
        public string UserId { get; set; }
        public List<OrderItemsDto?> OrderItems { get; set; }
    }
}