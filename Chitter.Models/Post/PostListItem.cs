namespace Chitter.Models.Post
{
    public class PostListItem
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}