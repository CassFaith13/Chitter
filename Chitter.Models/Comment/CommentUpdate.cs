using System.ComponentModel.DataAnnotations;

namespace Chitter.Models.Comment
{
    public class CommentUpdate
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string? Text { get; set; }
    }
}