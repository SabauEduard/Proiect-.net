using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Belong;
using Proiect_.net.Models.Enums;
using Proiect_.net.Services.BelongsService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BelongsController : ControllerBase
    {
        private readonly IBelongsService _belongsService;

        public BelongsController(IBelongsService belongsService)
        {
            _belongsService = belongsService;
        }

        [HttpPost]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> AddBelongs(BelongsRequestDTO newBelongs)
        {
            await _belongsService.CreateBelongs(newBelongs.BookId, newBelongs.CategoryId);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> DeleteBelongs(Guid id)
        {
            await _belongsService.DeleteBelonbgsById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetBelongsById(Guid id)
        {
            var belongs = await _belongsService.GetBelongsById(id);
            return belongs is null ? NotFound() : Ok(belongs);
        }
        [HttpGet]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> GetAllBelongs()
        {
            return Ok(await _belongsService.GetAllBelongs());
        }

    }
}
