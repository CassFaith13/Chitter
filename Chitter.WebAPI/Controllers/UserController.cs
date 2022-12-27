using Chitter.Services.User;
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
    }
}