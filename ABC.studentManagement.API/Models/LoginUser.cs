﻿using System.ComponentModel.DataAnnotations;

namespace ABC.studentManagement.API.Models
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
