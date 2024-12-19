using Book.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    public class BooksController : ControllerBase 
    {
        private  readonly IBookServices bookServices;
        public BooksController (IBookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        [HttpGet("search")]
        public async Task<IActionResult>SearchBooks(string title)
        {
            var result = await bookServices.SearchBookAsync(title);
            return Ok(result);
        }
    }
}
