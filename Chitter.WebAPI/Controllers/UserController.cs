using Chitter.Models.Token;
using Chitter.Models.User;
using Chitter.Services.Token;
using Chitter.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chitter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Register Chitter User")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterUserAsync(model);

            if (registerResult)
            {
                return Ok("New Chitter user successfully registered!");
            }
            return BadRequest("New Chitter user could NOT be created. Please try again.");
        }

        [Authorize]
        [HttpGet, Route("{userID}")]
        public async Task<IActionResult> GetByID(int userID)
        {
            var userInfo = await _userService.GetUserByIDAsync(userID);

            if (userInfo is null)
            {
                return NotFound();
            }
            return Ok(userInfo);
        }

        [HttpPost, Route("~/api/Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokenResponse = await _tokenService.GetTokenAsync(request);

            if (tokenResponse is null)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok(tokenResponse);
        }
    }
}