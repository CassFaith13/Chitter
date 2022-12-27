using Chitter.Models.Post;

namespace Chitter.Services.Posts
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreate post);
        Task<IEnumerable<PostListItem> GetAllPostsAsync();
        Task<PostInfo> GetPostByIDAsync(int postID);
        Task<bool> UpdatePostAsync(PostUpdate post);
        Task<bool> DeletePostAsync(int postID);
    }
}