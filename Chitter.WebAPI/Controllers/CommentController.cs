using Chitter.Data;
using Chitter.Data.Entities;
using Chitter.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace Chitter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private ApplicationDbContext _context;
        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPost = new Posts
            {
                Title = post.Title,
                Content = post.Content
            };

            await _context.Posts.AddAsync(newPost);

            return Ok("Post created successfully!");
        }
    }
}