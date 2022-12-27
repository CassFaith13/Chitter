using Chitter.Models.Post;
using Chitter.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Chitter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _postService.CreatePostAsync(post))
            {
                return Ok("Post created successfully!");
            }

            return BadRequest("Unable to create new post.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet, Route("{postID}")]
        public async Task<IActionResult> GetPostByID(int postID)
        {
            var info = await _postService.GetPostByIDAsync(postID);

            return info is not null
            ? Ok(info)
            : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostByID([FromBody] PostUpdate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _postService.UpdatePostAsync(post)
            ? Ok("Post successfully updated.")
            : BadRequest("Unable to update post.");
        }

        [HttpDelete, Route("{postID}")]
        public async Task<IActionResult> DeletePost(int postID)
        {
            return await _postService.DeletePostAsync(postID)
            ? Ok($"Post {postID} was deleted successfully.")
            : BadRequest($"Post {postID} could not be deleted.");
        }
    }
}