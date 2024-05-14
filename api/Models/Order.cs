using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public int TableId { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}