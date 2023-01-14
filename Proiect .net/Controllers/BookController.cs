using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_.net.Models.DTOs.Books;
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
        public async Task<IActionResult> AddBook(BookRequestDTO newBook)
        {
            await _bookService.CreateBook(newBook.ISBN, newBook.Title, newBook.Description, newBook.PageNumber, newBook.Language, newBook.ReleaseDate);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]Guid id)
        {
            var book = await _bookService.GetBook(id);
            return book is null? NotFound() : Ok(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}
