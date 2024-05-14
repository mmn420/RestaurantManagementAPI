using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace api.DTOs.User
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Phone number must e at most 15 characters long")]
        public string PhoneNumber { get; set; }
    }
}