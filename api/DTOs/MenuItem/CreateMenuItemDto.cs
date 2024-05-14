using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.DTOs.MenuItem
{
    public class CreateMenuItemDto
    {
        [Required]
        public string ItemName { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }
    }
}