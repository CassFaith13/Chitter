using System.ComponentModel.DataAnnotations;

namespace Chitter.Models.Reply
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string? Text { get; set; }
    }
}