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
        public int OwnerID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        // virtual list comments
        public virtual ICollection<CommentEntity> Comments { get; } = new List<CommentEntity>();
        // virtual list likes
        public virtual  ICollection<LikeEntity> Likes { get; } = new List<LikeEntity>();
        public Guid AuthorID { get; set; }
    }
}