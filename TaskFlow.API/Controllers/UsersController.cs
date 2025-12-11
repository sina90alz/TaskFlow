using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Users API is alive!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("only-admin")]
        public IActionResult OnlyAdmin()
        {
            return Ok("Admin endpoint");
        }

        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}
