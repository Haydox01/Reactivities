﻿using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\\d]).{4,8}", ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 number, 1 non-alphanumeric character, and at least 4 characters.")]


        public string Password { get; set; }
    }
}
