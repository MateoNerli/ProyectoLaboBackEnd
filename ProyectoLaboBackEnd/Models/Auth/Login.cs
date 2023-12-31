﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Auth
{
    public class Login
    {
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; } = null!;
    }
}
