using System.ComponentModel.DataAnnotations;

namespace Chitter.Models.Token
{
    public class TokenRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}