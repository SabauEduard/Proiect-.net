using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Models.DTOs.Write;
using Proiect_.net.Services.WritesService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritesController : ControllerBase
    {
        private readonly IWritesService _writesService;

        public WritesController(IWritesService writesService)
        {
            _writesService = writesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWrites(WritesRequestDTO newWrites)
        {
            await _writesService.CreateWrites(newWrites.AuthorId, newWrites.BookId);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWrites(Guid id)
        {
            await _writesService.DeleteWritesById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWrites(Guid id)
        {
            var writes = await _writesService.GetWritesById(id);
            return writes is null ? NotFound() : Ok(writes);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWrites()
        {
            return Ok(await _writesService.GetAllWrites());
        }
    }
}
