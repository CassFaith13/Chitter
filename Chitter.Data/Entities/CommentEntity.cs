using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chitter.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Text { get; set; }
        public Guid AuthorID { get; set; }
        public List<ReplyEntity> Replies { get; set; }
        [ForeignKey(nameof(ID))]
        public virtual ICollection<PostEntity> Posts { get; } = new List<PostEntity>();
    }
}