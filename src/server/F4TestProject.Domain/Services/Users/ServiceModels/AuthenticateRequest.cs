﻿using System.ComponentModel.DataAnnotations;

namespace F4TestProject.Domain.Services.Users.ServiceModels
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }


}
