using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chitter.Data.Entities
{
    public class LikeEntity
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(ID))]
        public virtual ICollection<PostEntity> Posts { get; } = new List<PostEntity>();
        public Guid OwnerID { get; set; }
        public bool IsLike { get; set; }
    }
}