using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Helpers.Attributes;
using Proiect_.net.Models.DTOs.Books;
using Proiect_.net.Models.Enums;
using Proiect_.net.Services.BookService;

namespace Proiect_.net.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> AddBook(BookRequestDTO newBook)
        {
            await _bookService.CreateBook(newBook.ISBN, newBook.Title, newBook.Description, newBook.PageNumber, newBook.Language, newBook.ReleaseDate);
            return Ok();
        }
        [HttpGet]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }
        [HttpGet("{id}")]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetBookById([FromRoute]Guid id)
        {
            var book = await _bookService.GetBookById(id);
            return book is null? NotFound() : Ok(book);
        }
        [HttpDelete("{id}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookService.DeleteBookById(id);
            return NoContent();
        }
    }
}
