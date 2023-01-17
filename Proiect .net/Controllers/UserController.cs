﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRegisterRequestDTO newUser)
        {
            return Ok(await _userService.CreateUser(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Username, newUser.Password));
        }

        [HttpPost("admin")]
        [Authorization(Role.Admin)]
        public async Task<ActionResult<UserResponseDTO>> AddAdmin(UserRegisterRequestDTO newAdmin)
        {
            return Ok(await _userService.CreateAdmin(newAdmin.FirstName, newAdmin.LastName, newAdmin.Email, newAdmin.Username, newAdmin.Password));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserResponseDTO>> Authenticate(UserLoginRequestDTO User)
        {
            var response = await _userService.Authenticate(User.Username, User.Password);
            return response is null ? BadRequest("Your username/email/password is wrong!") : Ok(response);
        }

        [HttpPost("refreshToken")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<ActionResult<string>> RefreshToken(string oldToken)
        {
            var response = await _userService.RefreshToken(oldToken);
            return response is null ? BadRequest("RefreshToken expired, authentication needed or Token is invalid!") : Ok(response);
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
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return user is null? NotFound() : Ok(user);
        }

        [HttpGet]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }
    }
}
