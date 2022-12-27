using System.Security.Claims;
using Chitter.Data;
using Chitter.Data.Entities;
using Chitter.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Chitter.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly int _userID;
        private readonly ApplicationDbContext _dbContext;
        public PostService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {   
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            var value = userClaims.FindFirst("ID")?.Value;

            var validID = int.TryParse(value, out _userID);

            if (!validID)
            {
                throw new Exception("Attempted to build NoteService without User ID claim.");
            }

            _dbContext = dbContext;
        }

        public async Task<bool> CreatePostAsync(PostCreate post)
        {
            var postEntity = new PostEntity
            {
                Title = post.Title,
                Content = post.Content,
                CreatedUtc = DateTimeOffset.Now,
                OwnerID = _userID
            };

            _dbContext.Posts.Add(postEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<PostListItem>> GetAllPostsAsync()
        {
            var posts = await _dbContext.Posts
            .Select(entity => new PostListItem
            {
                ID = entity.ID,
                Title = entity.Title,
                CreatedUtc = entity.CreatedUtc  
            })
            .ToListAsync();

            return posts;
        }

        public async Task<PostInfo?> GetPostByIDAsync(int postID)
        {
            var postEntity = await _dbContext.Posts
            .FirstOrDefaultAsync(e => 
            e.ID == postID);

            return postEntity is null ? null : new PostInfo
            {
                ID = postEntity.ID,
                Title = postEntity.Title,
                Content = postEntity.Content,
                CreatedUtc = postEntity.CreatedUtc,
                ModifiedUtc = postEntity.ModifiedUtc
            };
        }

        public async Task<bool> UpdatePostAsync(PostUpdate post)
        {
            var postEntity = await _dbContext.Posts.FindAsync(post.ID);

            if (postEntity?.OwnerID != _userID)
            {
                return false;
            }

            postEntity.Title = post.Title;
            postEntity.Content = post.Content;
            postEntity.ModifiedUtc = DateTimeOffset.Now;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeletePostAsync(int postID)
        {
            var postEntity = await _dbContext.Posts.FindAsync(postID);

            if (postEntity?.OwnerID != _userID)
            {
                return false;
            }

            _dbContext.Posts.Remove(postEntity);

            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}