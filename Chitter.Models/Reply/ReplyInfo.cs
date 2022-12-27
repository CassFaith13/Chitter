namespace Chitter.Models.Reply
{
    public class ReplyInfo
    {
        public int ID { get; set; }
        public string? Text { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}