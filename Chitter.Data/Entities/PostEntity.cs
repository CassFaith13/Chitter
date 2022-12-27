using System.ComponentModel.DataAnnotations;

namespace Chitter.Data.Entities
{
    public class PostEntity
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        // virtual list comments
        public List<CommentEntity> Comments { get; set; }
        // virtual list likes
        public List<LikeEntity> Likes { get; set; }
        public Guid AuthorID { get; set; }
    }
}