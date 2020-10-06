using System.ComponentModel.DataAnnotations;

namespace F4TestProject.Domain.Services.Users.ServiceModels
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "PasswordHash is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

    }
}
