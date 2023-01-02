﻿using System.ComponentModel.DataAnnotations;

namespace QAndA.Domain.Application.DTOs.Authentications.RequestDtos
{
    public class RegisterRequest
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }
        public string Roles { get; set; }
    }
}
