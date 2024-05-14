using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Table
{
    public class CreateTableDto
    {
        [Required]
        public int Capacity { get; set; }
    }
}