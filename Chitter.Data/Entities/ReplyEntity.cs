using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chitter.Data.Entities
{
    public class ReplyEntity
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(ID))]
        public virtual ICollection<CommentEntity> Comments { get; } = new List<CommentEntity>();
        public string? Text { get; set; }
        public Guid AuthorID { get; set; }
    }
}