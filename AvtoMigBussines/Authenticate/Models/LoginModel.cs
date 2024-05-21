﻿using System.ComponentModel.DataAnnotations;
namespace AvtoMigBussines.Authenticate.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
