using Chitter.Models.Comment;

namespace Chitter.Models.Reply
{
    public class ReplyListItem
    {
        public string? Text { get; set; }
        public Guid AuthorID { get; set; }
        public List<CommentListItem>     Comments { get; set; }
    }
}