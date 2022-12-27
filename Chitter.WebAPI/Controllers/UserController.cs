using Chitter.Models.User;
using Chitter.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chitter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Register Chitter User")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.RegisterUserAsync(model);

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
            var userInfo = await _service.GetUserByIDAsync(userID);

            if (userInfo is null)
            {
                return NotFound();
            }
            return Ok(userInfo);
        }
    }
}