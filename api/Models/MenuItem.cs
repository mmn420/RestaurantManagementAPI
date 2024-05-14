using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }
        public ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}