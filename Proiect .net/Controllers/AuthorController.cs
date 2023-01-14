using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Models.DTOs.Authors;
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
        public async Task<IActionResult> AddAuthor(AuthorRequestDTO newAuthor)
        {
            await _authorService.CreateAuthor(newAuthor.LastName, newAuthor.FirstName, newAuthor.Nationality);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _authorService.DeleteAuthorById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);
            return author is null ? NotFound() : Ok(author);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }
    }
}
