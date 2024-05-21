using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.MenuItem
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }
    }
}