using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Core.Model;
using ShoppingProject.Services;
using ShoppingProject.Services.Interfaces;

namespace ShoppingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddUser(string username, string password)
        {
            int userId = await _userService.AddUserAsync(username, password);
            return Ok(userId); // Wrapping the userId in an ActionResult<int>
        }

        [HttpPost("check-password")]
        public async Task<ActionResult<bool>> CheckUserPassword(string username, string password)
        {
            bool passwordCorrect = await _userService.CheckUserPasswordAsync(username, password);
            return Ok(passwordCorrect); // Wrapping the result in an ActionResult<bool>
        }
    }
}
