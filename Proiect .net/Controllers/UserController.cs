using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Books;
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

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRegisterRequestDTO newUser)
        {
            var user = await _userService.CreateUser(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Username, newUser.Password);
            return user is null ? BadRequest("Username is taken!") : Ok(user);
        }

        [HttpPost("admin")]
        [Authorization(Role.Admin)]
        public async Task<ActionResult<UserResponseDTO>> AddAdmin(UserRegisterRequestDTO newAdmin)
        {
           var admin = await _userService.CreateAdmin(newAdmin.FirstName, newAdmin.LastName, newAdmin.Email, newAdmin.Username, newAdmin.Password);
           return admin is null ? BadRequest("Username is taken!") : Ok(admin);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserResponseDTO>> Authenticate(UserLoginRequestDTO User)
        {
            var response = await _userService.Authenticate(User.Username, User.Password);
            return response is null ? BadRequest("Your username/email/password is wrong!") : Ok(response);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<UserResponseDTO>> RefreshToken([FromBody]RefreshTokenRequestDTO request)
        {
            var response = await _userService.RefreshToken(request.Token);
            return response is null ? BadRequest("RefreshToken has expired!") : Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserById(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<ActionResult<UserWithoutTokensResponseDTO>> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return user is null? NotFound() : Ok(user);
        }

        [HttpGet]
        [Authorization(Role.Admin)]
        public async Task<ActionResult<IEnumerable<UserWithoutTokensResponseDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("books{username}")]
        [Authorization(Role.Admin, Role.User)]
        public ActionResult<IEnumerable<BookResponseDTO>> GetBooksBorrowedByUser(string username)
        {
            return Ok(_userService.GetBooksBorrowedByUser(username));
        }

        [HttpGet("usersWpenalties")]
        [Authorization(Role.Admin)]
        public ActionResult<IEnumerable<UserWithPenaltiesResponseDTO>> GetUsersWithPenalties()
        {
            return Ok(_userService.GetPenaltiesOfUsers());
        }

    }
}
