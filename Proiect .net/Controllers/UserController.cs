using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Users;
using Proiect_.net.Models.Enums;
using Proiect_.net.Services.UserService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRegisterRequestDTO newUser)
        {
            return Ok(await _userService.CreateUser(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Username, newUser.Password));           
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserResponseDTO>> Authenticate(UserLoginRequestDTO User)
        {
            var response = await _userService.Authenticate(User.Username, User.Password);
            return response is null ? BadRequest("Your username/email/password is wrong!") : Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return user is null? NotFound() : Ok(user);
        }
        [HttpGet]
        [Authorization(Role.User)]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }
    }
}
