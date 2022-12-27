using Chitter.Models.Post;
using Chitter.Models.Reply;

namespace Chitter.Models.Comment
{
    public class CommentListItem
    {
        public string? Text { get; set; }
        public Guid AuthorID { get; set; }
        public List<ReplyListItem> Replies { get; set; }
        public List<PostListItem> Posts { get; set; }
    }
}