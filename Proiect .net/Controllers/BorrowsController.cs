using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Borrow;
using Proiect_.net.Models.Enums;
using Proiect_.net.Services.BorrowsService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowsController : ControllerBase
    {
        private readonly IBorrowsService _borrowsService;

        public BorrowsController(IBorrowsService borrowsService)
        {
            _borrowsService = borrowsService;
        }

        [HttpPost]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> AddBorrows(BorrowsRequestDTO newBorrows)
        {
            await _borrowsService.CreateBorrows(newBorrows.BookId, newBorrows.UserId);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> DeleteBorrows(Guid id)
        {
            var borrows = await _borrowsService.GetBorrowsById(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetBorrowsById(Guid id)
        {
            var borrows = await _borrowsService.GetBorrowsById(id);
            return borrows is null? NotFound() : Ok(borrows);
        }
        [HttpGet]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> GetAllBorrows()
        {
            return Ok(await _borrowsService.GetAllBorrows());
        }
     
    }
}
