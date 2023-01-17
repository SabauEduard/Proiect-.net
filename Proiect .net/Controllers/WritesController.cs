using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Write;
using Proiect_.net.Models.Enums;
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
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> AddWrites(WritesRequestDTO newWrites)
        {
            await _writesService.CreateWrites(newWrites.AuthorId, newWrites.BookId);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> DeleteWrites(Guid id)
        {
            await _writesService.DeleteWritesById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetWrites(Guid id)
        {
            var writes = await _writesService.GetWritesById(id);
            return writes is null ? NotFound() : Ok(writes);
        }
        [HttpGet]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> GetAllWrites()
        {
            return Ok(await _writesService.GetAllWrites());
        }
    }
}
