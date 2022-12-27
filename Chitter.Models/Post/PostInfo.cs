namespace Chitter.Models.Post
{
    public class PostInfo
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}