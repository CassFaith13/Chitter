using System.ComponentModel.DataAnnotations;

namespace Chitter.Models.User
{
    public class UserRegister
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(4)]
        public string? Username { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}