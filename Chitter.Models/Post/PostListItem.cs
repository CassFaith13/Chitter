using Chitter.Models.Comment;
using Chitter.Models.Like;

namespace Chitter.Models.Post
{
    public class PostListItem
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public List<CommentListItem> Comments { get; set; }
        public List<LikeListItem> Likes { get; set; }
    }
}