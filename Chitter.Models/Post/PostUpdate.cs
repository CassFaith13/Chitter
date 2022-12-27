using System.ComponentModel.DataAnnotations;

namespace Chitter.Models.Post
{
    public class PostUpdate
    {
        [Required]
        public int ID { get; set; }
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(25, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string? Title { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string? Content { get; set; }
    }
}