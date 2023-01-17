using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Authors;
using Proiect_.net.Models.Enums;
using Proiect_.net.Services.AuthorService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> AddAuthor(AuthorRequestDTO newAuthor)
        {
            await _authorService.CreateAuthor(newAuthor.LastName, newAuthor.FirstName, newAuthor.Nationality);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _authorService.DeleteAuthorById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);
            return author is null ? NotFound() : Ok(author);
        }
        [HttpGet]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }
    }
}
